using FishMarketing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
    public class UserLoginData : IUserLogin
    {
        private readonly FishMarketContext db;
        public UserLoginData(FishMarketContext _db)//Dependancy Injuction
        {
            db = _db;
        }
        public LoginTable GetLoginDetails(string uname)
        {
            LoginTable loginData = new LoginTable();
            loginData = db.LoginTables.FirstOrDefault(a => a.Username == uname) ?? new LoginTable();

            return loginData;
        }
        public List<UserPrivilege> GetUserPrivileges(int loginId)
        {
            List<UserPrivilege> privileges = new List<UserPrivilege>();
            privileges = db.UserPrivileges.Where(a => a.LoginId == loginId).ToList();
          //var privileges1 = db.UserPrivileges.Where(a => a.LoginId == loginId).Include(a => a.Menu).ToList();
            return privileges;
        }
        public List<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();
            menus = db.Menus.Where(a => a.Status).ToList();
            return menus;
        }
        public string AddUserPrivileges(List<UserPrivilege> userPrivileges)
        {
            try
            {
                foreach (var priv in userPrivileges)
                {
                    if (priv.UserPrivilegeId == 0)
                        db.UserPrivileges.Add(priv);
                    else
                        db.UserPrivileges.Update(priv);
                }

                //_db.BoxMarks.Add(boxMark);
                db.SaveChanges();
                return "OK";
              
            }
            catch(Exception ex)
            {
                return "Faild";
            }


            
        }
    }
}
