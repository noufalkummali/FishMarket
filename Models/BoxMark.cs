using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class BoxMark
    {
        public BoxMark()
        {
            MarketBoxFlows = new HashSet<MarketBoxFlow>();
            PurchaseBoxFlows = new HashSet<PurchaseBoxFlow>();
        }

        public int BoxMarkId { get; set; }
        public string BoxMarkName { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<MarketBoxFlow> MarketBoxFlows { get; set; }
        public virtual ICollection<PurchaseBoxFlow> PurchaseBoxFlows { get; set; }
    }
}
