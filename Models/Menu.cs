using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class Menu
    {
        public Menu()
        {
            UserPrivileges = new HashSet<UserPrivilege>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int SortOrder { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public string Icon_Image { get; set; }

        public virtual ICollection<UserPrivilege> UserPrivileges { get; set; }
    }
}
