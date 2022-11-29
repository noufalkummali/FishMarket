using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class Ledger
    {
        public Ledger()
        {
            CashFlowCrLedgers = new HashSet<CashFlow>();
            CashFlowDrLedgers = new HashSet<CashFlow>();
            OpeningBalances = new HashSet<OpeningBalance>();
        }

        public int LedgerId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int LedgerGroupId { get; set; }
        public int? MarketOrPurchaeId { get; set; }
        public string Type { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public bool IsActive { get; set; }

        public virtual LedgerGroup LedgerGroup { get; set; }
        public virtual MarketAndPurchasePlace MarketOrPurchae { get; set; }
        public virtual ICollection<CashFlow> CashFlowCrLedgers { get; set; }
        public virtual ICollection<CashFlow> CashFlowDrLedgers { get; set; }
        public virtual ICollection<OpeningBalance> OpeningBalances { get; set; }
    }
}
