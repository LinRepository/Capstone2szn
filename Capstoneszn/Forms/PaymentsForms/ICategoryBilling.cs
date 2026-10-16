using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn.Forms.PaymentsForms
{
    internal interface ICategoryBilling
    {
        int BillId { get; }
        decimal Outstanding { get; }
        decimal Balance { get; }
        string TenantName { get; }
        bool CoversRoom { get; }
        decimal RoomOutstanding { get; }
        decimal OwedForMode { get; }
        int RoomTenantCount { get; }

        event EventHandler ContextChanged;

        void SetPreviewAmount(decimal amount);
        List<KeyValuePair<int, decimal>> WholeRoomSplit(decimal amount);
        string NameOf(int tenantId);
        decimal ShareOf(decimal amount);
    }
}
