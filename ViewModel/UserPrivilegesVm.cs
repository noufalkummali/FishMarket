using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.ViewModel
{
    public class UserPrivilegesVm
    {
        public int UserPrivilegeId { get; set; }
        public string MenuName { get; set; }
        public string controllerName { get; set; }
        public string ActionName { get; set; }
        public string Type { get; set; }
        public string Icon_Image { get; set; }
        public int LoginId { get; set; }
        public int MenuId { get; set; }
        public bool CreateAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool ViewAccess { get; set; }
        public bool DeleteAccess { get; set; }

    }
}
