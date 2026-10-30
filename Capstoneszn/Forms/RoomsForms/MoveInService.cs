using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.RoomsForms
{
    /// <summary>
    /// NEW (move-in redesign): saves a move-in. No screen code here - the
    /// forms collect the data, this class checks it and saves it.
    ///
    /// Two cases, decided by the room itself at the moment of saving:
    ///
    ///   VACANT room  - the first Rent bill is created, then paid through
    ///                  BillingHelper.RecordReceipt (the same payment path as
    ///                  Bill Management). Individual = one receipt per payer,
    ///                  Whole Room = one receipt for everyone.
    ///
    ///   OCCUPIED room (joiner) - people are added, nothing is billed or
    ///                  paid now. A paying joiner is on the room's NEXT bill.
    ///
    /// Everything happens in ONE transaction: all of it is saved, or none.
    /// Every rule is checked again here, even if the form checked it,
    /// because the room may have changed while the form was open.
    /// </summary>
    public static class MoveInService
    {
        public const string Cash = "Cash";
        public const string GCash = "GCash";
        private const string RentCategory = "Rent";

        /* =================================================================
           BASIC VALIDATION RULES (the forms use the same ones)
           ================================================================= */

        /// <summary>Letters (ñ and accents included), space, period, apostrophe, hyphen.</summary>
        public static bool IsValidName(string s)
        {
            return !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s.Trim(), @"^[\p{L} .'\-]+$");
        }

        /// <summary>Digits only, 11 to 20 (matches the database rule).</summary>
        public static bool IsValidContact(string s)
        {
            return !string.IsNullOrEmpty(s) && Regex.IsMatch(s, @"^[0-9]{11,20}$");
        }

        /// <summary>GCash reference: exactly 13 digits (same rule as RevisedBillingPaymentForm).</summary>
        public static bool IsValidGCashReference(string s)
        {
            return !string.IsNullOrEmpty(s) && Regex.IsMatch(s, @"^[0-9]{13}$");
        }

        /// <summary>Full = exactly what is due. More = Advance. (Less is never allowed at move-in.)</summary>
        public static string PaymentTypeFor(decimal amount, decimal due)
        {
            return amount == due ? "Full" : "Advance";
        }

        /// <summary>
        /// The share each payer owes on the first bill. Same rounding as
        /// BillGenerator: leftover centavos go to the first payer.
        ///   6000 / 2 -> 3000.00, 3000.00      1000 / 3 -> 333.34, 333.33, 333.33
        /// </summary>
        public static decimal[] ComputeShares(decimal roomPrice, int payerCount)
        {
            return BillGenerator.SplitEqually(roomPrice, payerCount);
        }


        /* =================================================================
           SAVE
           ================================================================= */

        /// <summary>
        /// Saves the whole move-in. Throws InvalidOperationException with a
        /// message for the landlord when a rule is broken - nothing is saved.
        /// </summary>
        public static MoveInResult SaveMoveIn(MoveInData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            data.UseSinglePersonIfNoList();
            ValidateInput(data);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        MoveInResult result = SaveInsideTransaction(conn, tx, data, DateTime.Today);
                        tx.Commit();
                        return result;
                    }
                    catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                    {
                        // A unique rule in the database said no. Say which one in words.
                        TryRollback(tx);
                        throw new InvalidOperationException(DuplicateMessage(ex) + " Nothing was saved.");
                    }
                    catch
                    {
                        TryRollback(tx);
                        throw;
                    }
                }
            }
        }

        private static MoveInResult SaveInsideTransaction(
            SqlConnection conn, SqlTransaction tx, MoveInData data, DateTime today)
        {
            // ---- 1. Lock the room and read it fresh -------------------------
            //  UPDLOCK: a second move-in into this room waits until we finish,
            //  so two people can never take the last slot at the same time.
            int capacity, activeTenants, occupants;
            decimal roomPrice;
            bool archived;
            DateTime? anchor;

            using (var cmd = new SqlCommand(@"
                SELECT r.Capacity, r.RoomPrice, r.IsArchived, r.BillingAnchorDate,
                       v.ActiveTenants, v.Occupants
                FROM   Rooms r WITH (UPDLOCK, HOLDLOCK)
                JOIN   vwRoomStatus v ON v.RoomId = r.RoomId
                WHERE  r.RoomId = @rid;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        throw new InvalidOperationException("This room no longer exists.");

                    capacity = rd.GetInt32(0);
                    roomPrice = rd.GetDecimal(1);
                    archived = rd.GetBoolean(2);
                    anchor = rd.IsDBNull(3) ? (DateTime?)null : rd.GetDateTime(3);
                    activeTenants = rd.GetInt32(4);
                    occupants = rd.GetInt32(5);
                }
            }

            if (archived)
                throw new InvalidOperationException("This room is archived. Restore it before moving anyone in.");

            if (roomPrice <= 0m)
                throw new InvalidOperationException("This room has no price set.");

            int newPeople = data.Payers.Count + data.Dependents.Count;
            int freeSlots = capacity - occupants;
            if (newPeople > freeSlots)
                throw new InvalidOperationException(
                    "This room has " + freeSlots + " free slot(s), but " + newPeople +
                    " people are moving in. Payers and dependents both take a slot.");

            bool vacant = activeTenants == 0;

            // The room changed while the form was open: start again, because
            // the screen showed the wrong thing (pay now vs. pay nothing now).
            if (vacant && !data.ExpectVacant)
                throw new InvalidOperationException(
                    "This room became empty while the form was open, so a move-in payment is now needed. " +
                    "Please start the move-in again.");
            if (!vacant && data.ExpectVacant)
                throw new InvalidOperationException(
                    "Someone moved into this room while the form was open, so no move-in payment is taken now. " +
                    "Please start the move-in again.");

            if (vacant && data.Payers.Count == 0)
                throw new InvalidOperationException(
                    "An empty room needs at least one paying tenant. Dependents cannot move in alone.");

            decimal[] shares = vacant ? ComputeShares(roomPrice, data.Payers.Count) : new decimal[0];
            if (vacant) ValidatePayments(data, roomPrice, shares);

            // ---- 2. The paying tenants: person + stay -----------------------
            var tenantIds = new List<int>();
            var tenancyIds = new List<int>();

            foreach (MoveInPayer p in data.Payers)
            {
                int tenantId = p.ExistingTenantId > 0
                    ? CheckReturningTenant(conn, tx, p.ExistingTenantId, today)
                    : InsertTenant(conn, tx, p);

                int tenancyId;
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    OUTPUT INSERTED.TenancyId
                    VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                    tenancyId = (int)cmd.ExecuteScalar();
                }

                tenantIds.Add(tenantId);
                tenancyIds.Add(tenancyId);
            }

            // ---- 3. Dependents: linked to their head's stay -----------------
            foreach (MoveInDependent d in data.Dependents)
            {
                int headTenancyId = d.HeadIndex >= 0
                    ? tenancyIds[d.HeadIndex]
                    : FindActiveTenancy(conn, tx, d.HeadTenantId, data.RoomId);

                using (var cmd = new SqlCommand(@"
                    INSERT INTO Dependents (TenancyId, FirstName, MiddleName, LastName, ContactNumber, MoveInDate)
                    VALUES (@ten, @fn, @mn, @ln, @contact, @date);", conn, tx))
                {
                    cmd.Parameters.Add("@ten", SqlDbType.Int).Value = headTenancyId;
                    cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = d.FirstName.Trim();
                    cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value = NullIfBlank(d.MiddleName);
                    cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = d.LastName.Trim();
                    cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = NullIfBlank(d.ContactNumber);
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                    cmd.ExecuteNonQuery();
                }
            }

            var result = new MoveInResult
            {
                RoomNumber = AuditLogger.RoomNumber(conn, tx, data.RoomId),
                PayingCount = data.Payers.Count,
                DependentCount = data.Dependents.Count,
                MoveInDate = today
            };

            if (vacant)
            {
                // ---- 4. The room's billing cycle starts today ---------------
                using (var cmd = new SqlCommand(
                    "UPDATE Rooms SET BillingAnchorDate = @today WHERE RoomId = @rid;", conn, tx))
                {
                    cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                    cmd.ExecuteNonQuery();
                }

                // ---- 5. The first Rent bill, with one frozen share per payer -
                int billId = CreateFirstBill(conn, tx, data.RoomId, today, roomPrice);

                for (int i = 0; i < tenantIds.Count; i++)
                {
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO BillTenants (BillId, TenantId, Share)
                        VALUES (@bid, @tid, @share);", conn, tx))
                    {
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantIds[i];
                        AddMoney(cmd, "@share", shares[i]);
                        cmd.ExecuteNonQuery();
                    }
                }

                // ---- 6. Pay it, through the Billing v2 payment path ---------
                result.Receipts = RecordPayments(conn, tx, data, tenantIds, shares, roomPrice, today);
                result.NextDue = today.AddMonths(1);
            }
            else
            {
                // Joiner: no bill, no payment. Their share starts on the next bill.
                // ORIGINAL: result.NextDue = NextDueDate(anchor, today);
                // NEW (option 1): the first bill NOT created yet. Bills are made
                // 7 days early, so the next due date's bill may already exist
                // without them - a bill once issued is never changed.
                result.NextDue = anchor.HasValue
                    ? BillGenerator.NextUnbilledPeriod(conn, tx, data.RoomId, anchor.Value, today)
                    : NextDueDate(anchor, today);
            }

            // ---- 7. Audit, same transaction ----------------------------------
            string who = string.Join(", ", data.Payers.Select(p => p.FullName));
            if (data.Dependents.Count > 0)
                who += (who.Length > 0 ? " + " : "") + "dependents " +
                       string.Join(", ", data.Dependents.Select(d => d.FullName));

            string how = !vacant ? " (joined, no payment)"
                       : data.WholeRoom ? " (Whole Room payment)"
                       : " (Individual payments)";

            AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move In",
                who + " moved into Room " + result.RoomNumber + " on " + today.ToString("MMM dd, yyyy") + how);

            return result;
        }


        /* =================================================================
           STEPS
           ================================================================= */

        /// <summary>
        /// One receipt per payer (Individual) or one receipt for the room
        /// (Whole Room). Several receipts in one move-in get a suffix:
        /// R20261028211501-1, -2, -3 (see the notes in the chat).
        /// </summary>
        private static List<MoveInReceiptLine> RecordPayments(
            SqlConnection conn, SqlTransaction tx, MoveInData data,
            List<int> tenantIds, decimal[] shares, decimal roomPrice, DateTime today)
        {
            var receipts = new List<MoveInReceiptLine>();
            string baseNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");

            if (data.WholeRoom)
            {
                MoveInPayer payer = data.Payers[data.WholeRoomPayerIndex];
                var lines = new List<PaymentLine>
                {
                    new PaymentLine(RentCategory, payer.AmountPaid, PaymentTypeFor(payer.AmountPaid, roomPrice))
                };

                // NEW (credit choice): who gets the extra (null = split equally)
                int? extraTo = data.CreditToIndex.HasValue
                    ? tenantIds[data.CreditToIndex.Value]
                    : (int?)null;

                // ORIGINAL: BillingHelper.RecordReceipt(conn, tx, data.RoomId,
                // ORIGINAL:     tenantIds[data.WholeRoomPayerIndex], true, lines,
                // ORIGINAL:     payer.Method, RefOrNull(payer), today, Session.UserId, baseNo);
                BillingHelper.RecordReceipt(conn, tx, data.RoomId,
                    tenantIds[data.WholeRoomPayerIndex], true, lines,
                    payer.Method, RefOrNull(payer), today, Session.UserId, baseNo, extraTo);

                receipts.Add(new MoveInReceiptLine
                {
                    ReceiptNo = baseNo,
                    PayerName = payer.FullName + " (whole room)",
                    Method = payer.Method,
                    Amount = payer.AmountPaid
                });
            }
            else
            {
                for (int i = 0; i < data.Payers.Count; i++)
                {
                    MoveInPayer payer = data.Payers[i];
                    string receiptNo = data.Payers.Count == 1 ? baseNo : baseNo + "-" + (i + 1);

                    var lines = new List<PaymentLine>
                    {
                        new PaymentLine(RentCategory, payer.AmountPaid, PaymentTypeFor(payer.AmountPaid, shares[i]))
                    };

                    BillingHelper.RecordReceipt(conn, tx, data.RoomId,
                        tenantIds[i], false, lines,
                        payer.Method, RefOrNull(payer), today, Session.UserId, receiptNo);

                    receipts.Add(new MoveInReceiptLine
                    {
                        ReceiptNo = receiptNo,
                        PayerName = payer.FullName,
                        Method = payer.Method,
                        Amount = payer.AmountPaid
                    });
                }
            }

            return receipts;
        }

        /// <summary>
        /// The first Rent bill: today to the same day next month, due today.
        /// Same period shape BillGenerator uses, so the generator sees this
        /// period as already billed and continues from the next one.
        ///
        /// Re-let on the same day (kept from the old PaymentForm): if the
        /// previous occupants left on the day their bill started, a bill for
        /// today already exists. The room is let twice in that period, so the
        /// newcomers join THAT bill and its total rises by the room price.
        /// Old shares and payments are not touched.
        /// </summary>
        private static int CreateFirstBill(
            SqlConnection conn, SqlTransaction tx, int roomId, DateTime today, decimal roomPrice)
        {
            using (var cmd = new SqlCommand(@"
                SELECT BillId FROM Bills WITH (UPDLOCK, HOLDLOCK)
                WHERE  RoomId = @rid AND BillCategory = 'Rent' AND BillingPeriodStart = @start;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = today;
                object existing = cmd.ExecuteScalar();

                if (existing != null && existing != DBNull.Value)
                {
                    int billId = Convert.ToInt32(existing);
                    using (var up = new SqlCommand(
                        "UPDATE Bills SET Amount = Amount + @amt WHERE BillId = @bid;", conn, tx))
                    {
                        AddMoney(up, "@amt", roomPrice);
                        up.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        up.ExecuteNonQuery();
                    }
                    return billId;
                }
            }

            using (var cmd = new SqlCommand(@"
                INSERT INTO Bills (RoomId, BillCategory, BillingPeriodStart, BillingPeriodEnd, DueDate, Amount)
                OUTPUT INSERTED.BillId
                VALUES (@rid, 'Rent', @start, @end, @due, @amt);", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = today;
                cmd.Parameters.Add("@end", SqlDbType.Date).Value = today.AddMonths(1);
                cmd.Parameters.Add("@due", SqlDbType.Date).Value = today;
                AddMoney(cmd, "@amt", roomPrice);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static int InsertTenant(SqlConnection conn, SqlTransaction tx, MoveInPayer p)
        {
            // Contact numbers are unique per tenant (settled rule). Checked here
            // so the landlord gets a clear message, not a database error.
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Tenants WHERE ContactNumber = @c;", conn, tx))
            {
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 20).Value = (p.ContactNumber ?? "").Trim();
                if ((int)cmd.ExecuteScalar() > 0)
                    throw new InvalidOperationException(
                        "Contact number " + p.ContactNumber.Trim() + " (" + p.FullName +
                        ") already belongs to another tenant.");
            }

            using (var cmd = new SqlCommand(@"
                INSERT INTO Tenants (FirstName, MiddleName, LastName, Address, ContactNumber)
                OUTPUT INSERTED.TenantId
                VALUES (@fn, @mn, @ln, @addr, @contact);", conn, tx))
            {
                cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = p.FirstName.Trim();
                cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value = NullIfBlank(p.MiddleName);
                cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = p.LastName.Trim();
                cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value = p.Address.Trim();
                cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = p.ContactNumber.Trim();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Reactivation (moved here from the old PaymentForm): the returning
        /// tenant must have no active stay, and must have moved out before today.
        /// </summary>
        private static int CheckReturningTenant(SqlConnection conn, SqlTransaction tx, int tenantId, DateTime today)
        {
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Tenancies WHERE TenantId = @tid AND Status = 'Active';", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                if ((int)cmd.ExecuteScalar() > 0)
                    throw new InvalidOperationException(
                        "This tenant already has an active stay, so they cannot be reactivated again.");
            }

            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Tenancies WHERE TenantId = @tid AND MoveOutDate >= @date;", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                if ((int)cmd.ExecuteScalar() > 0)
                    throw new InvalidOperationException(
                        "This tenant moved out today. A returning tenant can be reactivated from the day after their move out.");
            }

            return tenantId;
        }

        private static int FindActiveTenancy(SqlConnection conn, SqlTransaction tx, int tenantId, int roomId)
        {
            using (var cmd = new SqlCommand(@"
                SELECT TenancyId FROM Tenancies
                WHERE  TenantId = @tid AND RoomId = @rid AND Status = 'Active';", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                object o = cmd.ExecuteScalar();
                if (o == null || o == DBNull.Value)
                    throw new InvalidOperationException(
                        "The head tenant of a dependent no longer lives in this room.");
                return Convert.ToInt32(o);
            }
        }


        /* =================================================================
           VALIDATION
           ================================================================= */

        /// <summary>Rules that need no database: names, contacts, who is whose dependent.</summary>
        private static void ValidateInput(MoveInData data)
        {
            if (data.RoomId <= 0)
                throw new InvalidOperationException("No room selected.");

            if (data.Payers.Count + data.Dependents.Count == 0)
                throw new InvalidOperationException("Add at least one person to move in.");

            foreach (MoveInPayer p in data.Payers)
            {
                if (p.ExistingTenantId > 0) continue;   // returning tenant: details already on file

                if (!IsValidName(p.FirstName) || !IsValidName(p.LastName))
                    throw new InvalidOperationException(
                        "First and last name are required and may contain letters, spaces, . ' - only (" + p.FullName + ").");
                if (!string.IsNullOrWhiteSpace(p.MiddleName) && !IsValidName(p.MiddleName))
                    throw new InvalidOperationException("Middle name may contain letters, spaces, . ' - only (" + p.FullName + ").");
                if (string.IsNullOrWhiteSpace(p.Address))
                    throw new InvalidOperationException("Address is required (" + p.FullName + ").");
                if (!IsValidContact(p.ContactNumber?.Trim()))
                    throw new InvalidOperationException("Contact number must be 11 to 20 digits (" + p.FullName + ").");
            }

            var contacts = data.Payers.Where(p => p.ExistingTenantId == 0)
                                      .Select(p => (p.ContactNumber ?? "").Trim()).ToList();
            if (contacts.Distinct().Count() != contacts.Count)
                throw new InvalidOperationException("Two paying tenants in the list have the same contact number.");

            foreach (MoveInDependent d in data.Dependents)
            {
                if (!IsValidName(d.FirstName) || !IsValidName(d.LastName))
                    throw new InvalidOperationException(
                        "A dependent's first and last name are required and may contain letters, spaces, . ' - only (" + d.FullName + ").");
                if (!string.IsNullOrWhiteSpace(d.MiddleName) && !IsValidName(d.MiddleName))
                    throw new InvalidOperationException("Middle name may contain letters, spaces, . ' - only (" + d.FullName + ").");
                if (!string.IsNullOrWhiteSpace(d.ContactNumber) && !IsValidContact(d.ContactNumber.Trim()))
                    throw new InvalidOperationException("A dependent's contact number, if given, must be 11 to 20 digits (" + d.FullName + ").");

                bool headInList = d.HeadIndex >= 0 && d.HeadIndex < data.Payers.Count;
                if (!headInList && d.HeadTenantId <= 0)
                    throw new InvalidOperationException("Choose who " + d.FullName + " is a dependent of.");
            }
        }

        /// <summary>
        /// Vacant room only. The move-in policy is "full payment before
        /// occupying": nobody pays less than what is due. More is allowed
        /// and becomes advance credit (Rent).
        /// </summary>
        private static void ValidatePayments(MoveInData data, decimal roomPrice, decimal[] shares)
        {
            var payersWhoPay = new List<int>();

            if (data.WholeRoom)
            {
                if (data.WholeRoomPayerIndex < 0 || data.WholeRoomPayerIndex >= data.Payers.Count)
                    throw new InvalidOperationException("Choose who pays for the whole room.");

                MoveInPayer payer = data.Payers[data.WholeRoomPayerIndex];
                if (payer.AmountPaid < roomPrice)
                    throw new InvalidOperationException(
                        payer.FullName + " must pay at least the room price: PHP " + roomPrice.ToString("N2") + ".");

                payersWhoPay.Add(data.WholeRoomPayerIndex);

                // NEW (credit choice): a chosen tenant must be one of the payers.
                if (data.CreditToIndex.HasValue &&
                    (data.CreditToIndex.Value < 0 || data.CreditToIndex.Value >= data.Payers.Count))
                    throw new InvalidOperationException("Choose who gets the extra credit.");
            }
            else
            {
                for (int i = 0; i < data.Payers.Count; i++)
                {
                    if (data.Payers[i].AmountPaid < shares[i])
                        throw new InvalidOperationException(
                            data.Payers[i].FullName + " must pay at least their share: PHP " + shares[i].ToString("N2") + ".");
                    payersWhoPay.Add(i);
                }
            }

            var references = new List<string>();

            foreach (int i in payersWhoPay)
            {
                MoveInPayer p = data.Payers[i];

                if (p.AmountPaid != Math.Round(p.AmountPaid, 2))
                    throw new InvalidOperationException("Amounts can have at most 2 decimal places (" + p.FullName + ").");

                if (p.Method != Cash && p.Method != GCash)
                    throw new InvalidOperationException("Choose Cash or GCash (" + p.FullName + ").");

                if (p.Method == GCash)
                {
                    string reference = (p.ReferenceNo ?? "").Trim();
                    if (!IsValidGCashReference(reference))
                        throw new InvalidOperationException(
                            "GCash reference number must be exactly 13 digits (" + p.FullName + ").");
                    references.Add(reference);
                }
            }

            if (references.Distinct().Count() != references.Count)
                throw new InvalidOperationException("Two payers have the same GCash reference number.");
        }


        /* =================================================================
           SMALL HELPERS
           ================================================================= */

        /// <summary>The next period start after today, from the room's fixed anchor (same as BillGenerator).</summary>
        private static DateTime NextDueDate(DateTime? anchor, DateTime today)
        {
            if (!anchor.HasValue) return today;

            int n = 0;
            while (anchor.Value.AddMonths(n) <= today) n++;
            return anchor.Value.AddMonths(n);
        }

        private static string RefOrNull(MoveInPayer p)
        {
            // Cash must store NULL (CK_Payments_Reference).
            return p.Method == GCash ? p.ReferenceNo.Trim() : null;
        }

        private static object NullIfBlank(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s.Trim();
        }

        private static void AddMoney(SqlCommand cmd, string name, decimal value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = value;
        }

        private static void TryRollback(SqlTransaction tx)
        {
            try { tx.Rollback(); }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private static string DuplicateMessage(SqlException ex)
        {
            string m = ex.Message;
            if (m.Contains("UQ_Tenants_Contact")) return "A contact number is already used by another tenant.";
            if (m.Contains("UX_Payments_ReferenceNo")) return "A GCash reference number has already been recorded.";
            if (m.Contains("UQ_Payments_ReceiptNo")) return "A receipt number was already used. Please try again.";
            if (m.Contains("UX_Tenancies_OneActive")) return "A tenant in the list already has an active stay.";
            return "A record already exists (" + m + ").";
        }
    }
}