using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class MarketAndPurchasePlace
    {
        public MarketAndPurchasePlace()
        {
            FlowMasters = new HashSet<FlowMaster>();
            Ledgers = new HashSet<Ledger>();
            MarketBoxFlows = new HashSet<MarketBoxFlow>();
            PurchaseBoxFlows = new HashSet<PurchaseBoxFlow>();
        }

        public int MarketPurchasePlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string MobileNumber { get; set; }
        public string ContactName { get; set; }
        public decimal? ProfCommission { get; set; }
        public decimal Deposit { get; set; }
        public decimal Advance { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public int Clogin { get; set; }
        public int? Mlogin { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }

        public virtual ICollection<FlowMaster> FlowMasters { get; set; }
        public virtual ICollection<Ledger> Ledgers { get; set; }
        public virtual ICollection<MarketBoxFlow> MarketBoxFlows { get; set; }
        public virtual ICollection<PurchaseBoxFlow> PurchaseBoxFlows { get; set; }
    }
}
