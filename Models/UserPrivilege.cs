using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class UserPrivilege
    {
        public int UserPrivilegeId { get; set; }
        public int LoginId { get; set; }
        public int MenuId { get; set; }
        public bool CreateAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool ViewAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public int CloginId { get; set; }
        public DateTime Cdate { get; set; }
        public int? MloginId { get; set; }
        public DateTime? Mdate { get; set; }

        public virtual LoginTable Clogin { get; set; }
        public virtual LoginTable Login { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual LoginTable Mlogin { get; set; }
    }
}
