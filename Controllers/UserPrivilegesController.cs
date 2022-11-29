using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishMarketing.Data;
using FishMarketing.Models;
using FishMarketing.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishMarketing.Controllers
{
    public class UserPrivilegesController : Controller
    {
        private readonly IUserLogin userLogin;
        public UserPrivilegesController(IUserLogin _userLogin)
        {
            userLogin = _userLogin;
        }
        // GET: UserPrivilegesController1
        public ActionResult Index(int id=0)
        {
            if(id==0)
                id= HttpContext.Session.GetInt32("UserLoginId")??0;
            List<UserPrivilegesVm> userPrivilegesVm = new List<UserPrivilegesVm>();
            UserPrivilegesVm privilegesVm = new UserPrivilegesVm();

            var userPrivileges = userLogin.GetUserPrivileges(id);
            var menus = userLogin.GetMenus();
            foreach(var menu in menus)
            {
                privilegesVm = new UserPrivilegesVm();
                var priv = userPrivileges.FirstOrDefault(a => a.MenuId == menu.MenuId)??new UserPrivilege();                              
                privilegesVm.ActionName = menu.ActionName;
                privilegesVm.controllerName = menu.ControllerName;
                privilegesVm.MenuName = menu.MenuName;
                privilegesVm.Type = menu.Type;
                privilegesVm.CreateAccess = priv.CreateAccess;
                privilegesVm.DeleteAccess = priv.DeleteAccess;
                privilegesVm.EditAccess = priv.EditAccess;
                privilegesVm.ViewAccess = priv.ViewAccess;               
                privilegesVm.MenuId = menu.MenuId;
                privilegesVm.UserPrivilegeId = priv.UserPrivilegeId;
                privilegesVm.Icon_Image = menu.Icon_Image;
                privilegesVm.LoginId = id;

                userPrivilegesVm.Add(privilegesVm);
            }

            return View(userPrivilegesVm);
        }

        // POST: UserPrivilegesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<UserPrivilegesVm> userPrivilegesVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userLoginId = HttpContext.Session.GetInt32("UserLoginId") ?? 0;
                    int loginId = userPrivilegesVm.FirstOrDefault().LoginId;
                    List<UserPrivilege> userPrivilegeList = new List<UserPrivilege>();
                    UserPrivilege privilege = new UserPrivilege();
                    var savedUserPrivileges = userLogin.GetUserPrivileges(loginId);
                    foreach (var priv in userPrivilegesVm)
                    {
                        privilege = new UserPrivilege();
                        privilege = savedUserPrivileges.FirstOrDefault(a => a.MenuId == priv.MenuId) ?? new UserPrivilege();
                        if (privilege.UserPrivilegeId == 0)
                        {
                            privilege.MenuId = priv.MenuId;
                            privilege.LoginId = loginId;
                            privilege.Cdate = DateTime.Now;
                            privilege.CloginId = userLoginId;
                        }
                        else
                        {
                            privilege.Mdate = DateTime.Now;
                            privilege.MloginId = userLoginId;
                        }                       
                        privilege.CreateAccess = priv.CreateAccess;
                        privilege.DeleteAccess = priv.DeleteAccess;
                        privilege.EditAccess = priv.EditAccess;
                        privilege.ViewAccess = priv.ViewAccess;
                        
                        
                        userPrivilegeList.Add(privilege);
                    }
                    string res = userLogin.AddUserPrivileges(userPrivilegeList);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(userPrivilegesVm);
        }

        
    }
}
