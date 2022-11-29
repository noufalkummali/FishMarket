using FishMarketing.Data;
using FishMarketing.Settings;
using FishMarketing.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.ViewComponents
{
    [ViewComponent(Name = "SideMenus")]
    public class SideMenusViewComponent : ViewComponent
    {
        private readonly IUserLogin userLogin;
        public SideMenusViewComponent(IUserLogin _userLogin)
        {
            userLogin = _userLogin;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int loginId = (int)HttpContext.Session.GetInt32("UserLoginId");
            var privileges = HttpContext.Session.GetObject<List<UserPrivilegesVm>>("MySession");
            return View("Index", privileges);
        }

    }
}
