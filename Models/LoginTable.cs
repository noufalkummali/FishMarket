using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class LoginTable
    {
        public LoginTable()
        {
            CashFlowCloginNavigations = new HashSet<CashFlow>();
            CashFlowMloginNavigations = new HashSet<CashFlow>();
            FlowMasterClogins = new HashSet<FlowMaster>();
            FlowMasterMlogins = new HashSet<FlowMaster>();
            OpeningBalanceClogins = new HashSet<OpeningBalance>();
            OpeningBalanceMlogins = new HashSet<OpeningBalance>();
            UserPrivilegeClogins = new HashSet<UserPrivilege>();
            UserPrivilegeLogins = new HashSet<UserPrivilege>();
            UserPrivilegeMlogins = new HashSet<UserPrivilege>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginType { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual ICollection<CashFlow> CashFlowCloginNavigations { get; set; }
        public virtual ICollection<CashFlow> CashFlowMloginNavigations { get; set; }
        public virtual ICollection<FlowMaster> FlowMasterClogins { get; set; }
        public virtual ICollection<FlowMaster> FlowMasterMlogins { get; set; }
        public virtual ICollection<OpeningBalance> OpeningBalanceClogins { get; set; }
        public virtual ICollection<OpeningBalance> OpeningBalanceMlogins { get; set; }
        public virtual ICollection<UserPrivilege> UserPrivilegeClogins { get; set; }
        public virtual ICollection<UserPrivilege> UserPrivilegeLogins { get; set; }
        public virtual ICollection<UserPrivilege> UserPrivilegeMlogins { get; set; }
    }
}
