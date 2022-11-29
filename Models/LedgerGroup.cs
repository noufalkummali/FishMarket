using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class LedgerGroup
    {
        public LedgerGroup()
        {
            Ledgers = new HashSet<Ledger>();
        }

        public int LedgerGroupId { get; set; }
        public string GroupName { get; set; }
        public string Type { get; set; }
        public string DrOrCr { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual ICollection<Ledger> Ledgers { get; set; }
    }
}
