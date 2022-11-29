using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class PurchaseBoxFlow
    {
        public int PurchaseBoxFlowId { get; set; }
        public int PurchasePlaceId { get; set; }
        public int InvardBoxQty { get; set; }
        public int OutvardBoxQty { get; set; }
        public int FlowMasterId { get; set; }
        public int? BoxMarkId { get; set; }
        public string Remarks { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public string DriverName { get; set; }
        public string HelperName { get; set; }
        public string DriverMobile { get; set; }
        public string HelperMobile { get; set; }
        public string VehicleNumber { get; set; }

        public virtual BoxMark BoxMark { get; set; }
        public virtual FlowMaster FlowMaster { get; set; }
        public virtual MarketAndPurchasePlace PurchasePlace { get; set; }
    }
}
