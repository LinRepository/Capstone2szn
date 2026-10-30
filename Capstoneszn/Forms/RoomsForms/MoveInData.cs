using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn.Forms.RoomsForms
{
    public class MoveInData
    {
        public int RoomId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOccupied { get; set; }

        /// <summary>
        /// 0 = a new person (a Tenants row is inserted).
        /// Above 0 = a RETURNING tenant being reactivated from Settings >
        /// Archive: the existing Tenants row is reused and only a new stay
        /// (Tenancies row) is added, so their whole history stays together.
        /// </summary>
        public int ExistingTenantId { get; set; }

        /* =================================================================
           NEW (move-in redesign): a group move-in.

           The single-person fields above are kept so older callers still
           work (ReactivateTenantForm fills them). MoveInService turns them
           into Payers[0] when the lists below are empty.
           ================================================================= */

        /// <summary>The paying tenants moving in, in the order they were added.</summary>
        public List<MoveInPayer> Payers { get; set; } = new List<MoveInPayer>();

        /// <summary>Non-paying occupants. Each one belongs to a head payer.</summary>
        public List<MoveInDependent> Dependents { get; set; } = new List<MoveInDependent>();

        /// <summary>True = one payer pays the whole room. False = each payer pays their own share.</summary>
        public bool WholeRoom { get; set; }

        /// <summary>Whole Room only: which payer (index in Payers) hands over the money.</summary>
        public int WholeRoomPayerIndex { get; set; }

        /// <summary>
        /// NEW (credit choice): Whole Room only - who gets the EXTRA money
        /// (what is paid above the room price). Index in Payers, or
        /// null = split equally. PaymentForm defaults it to the payer.
        /// </summary>
        public int? CreditToIndex { get; set; }

        /// <summary>
        /// What the screen believed when it opened: true = the room was empty
        /// (payment needed), false = someone already lives there (no payment).
        /// The save re-checks this, in case the room changed while the form was open.
        /// </summary>
        public bool ExpectVacant { get; set; }

        /// <summary>
        /// Older callers fill only the single-person fields. Turn them into
        /// one payer so the new save handles both the same way.
        /// </summary>
        public void UseSinglePersonIfNoList()
        {
            if (Payers.Count > 0 || Dependents.Count > 0) return;

            Payers.Add(new MoveInPayer
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Address = Address,
                ContactNumber = ContactNumber,
                ExistingTenantId = ExistingTenantId
            });
        }
    }

    /// <summary>NEW (move-in redesign): one paying tenant and, for a vacant room, what they paid.</summary>
    public class MoveInPayer
    {
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string ContactNumber { get; set; } = "";

        /// <summary>Above 0 = a returning tenant (reactivation); no new Tenants row.</summary>
        public int ExistingTenantId { get; set; }

        // ---- Payment (vacant room only; filled by PaymentForm) ----
        public decimal AmountPaid { get; set; }
        public string Method { get; set; } = "Cash";      // "Cash" / "GCash"
        public string ReferenceNo { get; set; } = "";     // GCash only

        public string FullName => (FirstName + " " + LastName).Trim();
    }

    /// <summary>NEW (move-in redesign): a non-paying occupant (spouse, child, parent...).</summary>
    public class MoveInDependent
    {
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ContactNumber { get; set; } = "";   // optional

        /// <summary>The head is a payer in THIS move-in: their index in Payers. -1 if not.</summary>
        public int HeadIndex { get; set; } = -1;

        /// <summary>The head already lives in the room (joiner case): their TenantId. 0 if not.</summary>
        public int HeadTenantId { get; set; }

        public string FullName => (FirstName + " " + LastName).Trim();
    }

    /// <summary>NEW (move-in redesign): what the save returns, for MoveInCompleteForm.</summary>
    public class MoveInResult
    {
        public string RoomNumber { get; set; } = "";
        public int PayingCount { get; set; }
        public int DependentCount { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime NextDue { get; set; }
        public List<MoveInReceiptLine> Receipts { get; set; } = new List<MoveInReceiptLine>();
    }
}