using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class FinancialYear
    {
        public FinancialYear()
        {
            CashFlows = new HashSet<CashFlow>();
            OpeningBalances = new HashSet<OpeningBalance>();
        }

        public int FinancialYearId { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<CashFlow> CashFlows { get; set; }
        public virtual ICollection<OpeningBalance> OpeningBalances { get; set; }
    }
}
