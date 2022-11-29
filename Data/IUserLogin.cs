using FishMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
    public interface IUserLogin
    {
        LoginTable GetLoginDetails(string uname);
        List<UserPrivilege> GetUserPrivileges(int loginId);
        List<Menu> GetMenus();
        string AddUserPrivileges(List<UserPrivilege> userPrivilege);
    }
}
