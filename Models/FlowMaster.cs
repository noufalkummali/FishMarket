using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class FlowMaster
    {
        public FlowMaster()
        {
            CashFlows = new HashSet<CashFlow>();
            MarketBoxFlows = new HashSet<MarketBoxFlow>();
            PurchaseBoxFlows = new HashSet<PurchaseBoxFlow>();
        }

        public int FlowMasterId { get; set; }
        public DateTime Date { get; set; }
        public int? PurchasePlaceId { get; set; }
        public string Type { get; set; }
        public int PurchasedBox { get; set; }
        public int CloginId { get; set; }
        public int? MloginId { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Remarks { get; set; }

        public virtual LoginTable Clogin { get; set; }
        public virtual LoginTable Mlogin { get; set; }
        public virtual MarketAndPurchasePlace PurchasePlace { get; set; }
        public virtual ICollection<CashFlow> CashFlows { get; set; }
        public virtual ICollection<MarketBoxFlow> MarketBoxFlows { get; set; }
        public virtual ICollection<PurchaseBoxFlow> PurchaseBoxFlows { get; set; }
    }
}
