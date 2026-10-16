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

    }
}
