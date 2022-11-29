using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class OpeningBalance
    {
        public int OpeningBalanceId { get; set; }
        public int FinancialYearId { get; set; }
        public int LedgerId { get; set; }
        public string CrOrDr { get; set; }
        public decimal OpeningBalance1 { get; set; }
        public bool Status { get; set; }
        public int CloginId { get; set; }
        public DateTime Cdate { get; set; }
        public int? MloginId { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual LoginTable Clogin { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual Ledger Ledger { get; set; }
        public virtual LoginTable Mlogin { get; set; }
    }
}
