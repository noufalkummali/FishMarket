using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class CashFlow
    {
        public int CashFlowId { get; set; }
        public DateTime Date { get; set; }
        public int? CrLedgerId { get; set; }
        public int? DrLedgerId { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceNo { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public int Clogin { get; set; }
        public int? Mlogin { get; set; }
        public string RecievedBy { get; set; }
        public string Vehicle { get; set; }
        public string VoucherType { get; set; }
        public int FinancialYearId { get; set; }
        public int? FlowMasterId { get; set; }

        public virtual LoginTable CloginNavigation { get; set; }
        public virtual Ledger CrLedger { get; set; }
        public virtual Ledger DrLedger { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual FlowMaster FlowMaster { get; set; }
        public virtual LoginTable MloginNavigation { get; set; }
    }
}
