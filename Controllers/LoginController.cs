using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishMarketing.Data;
using FishMarketing.Settings;
using FishMarketing.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishMarketing.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLogin userLogin;
        
        public LoginController(IUserLogin _userLogin)
        {
            userLogin = _userLogin;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            //if(HttpContext.Session.GetInt32("UserLoginId") ==null)
            //{
            //    string test = "";
            //}
            return View();
        }

        
        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginVm loginVm)
        {
            try
            {
                var userlogin = userLogin.GetLoginDetails(loginVm.Username);
                if(userlogin==null && userlogin.LoginId==0)
                {
                    //not active user
                    return View();
                }
                if(userlogin.Password!= loginVm.Password)
                {
                    //incorrect password
                    return View();
                }
               // HttpContext.Session.SetObject("MySession", boxMarkListVm);
                HttpContext.Session.SetInt32("UserLoginId", userlogin.LoginId);
                HttpContext.Session.SetString("Username", userlogin.Username);
                HttpContext.Session.SetString("Password", userlogin.Password);
                HttpContext.Session.SetString("LoginType", userlogin.LoginType);

                var userPrivileges = userLogin.GetUserPrivileges(userlogin.LoginId);
                var menus = userLogin.GetMenus();
                List<UserPrivilegesVm> privilegesVms = new List<UserPrivilegesVm>();
                UserPrivilegesVm privilegesVm = new UserPrivilegesVm();
                 
                foreach (var priv in userPrivileges.Where(a=>a.CreateAccess||a.ViewAccess))
                {
                    privilegesVm = new UserPrivilegesVm();
                    var menu = menus.FirstOrDefault(a => a.MenuId == priv.MenuId);
                    if (menu == null)
                        continue;
                    privilegesVm.ActionName = menu.ActionName;
                    privilegesVm.controllerName = menu.ControllerName;
                    privilegesVm.MenuName = menu.MenuName;
                    privilegesVm.Type = menu.Type;
                    privilegesVm.CreateAccess = priv.CreateAccess;
                    privilegesVm.DeleteAccess = priv.DeleteAccess;
                    privilegesVm.EditAccess = priv.EditAccess;
                    privilegesVm.ViewAccess = priv.ViewAccess;
                    privilegesVm.LoginId = priv.LoginId;
                    privilegesVm.MenuId = priv.MenuId;
                    privilegesVm.UserPrivilegeId = priv.UserPrivilegeId;
                    privilegesVm.Icon_Image = menu.Icon_Image;
                    privilegesVms.Add(privilegesVm);


                }
                HttpContext.Session.SetObject("MySession", privilegesVms);

                //var t = HttpContext.Session.GetString("UserLoginId");
                //var s = HttpContext.Session.GetObject<List<UserPrivilegesVm>>("MySession");
                return RedirectToAction("Index", "BoxMarks");//dash board
            }
            catch(Exception ex)
            {
                
                return View();
            }
        }
        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }


    }
}
