using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Settings
{
   
    public class SessionValues:Controller
    {
      // public  IHttpContextAccessor HttpContextAccessor;
        public LoginUser LoginSession;
        public SessionValues() { }
        //public SessionValues(IHttpContextAccessor iHttpContextAccessor)
        //{
        //    HttpContextAccessor = iHttpContextAccessor;

        //    //return session;
        //}

        //public LoginUser GetSession()
        //{
        //    LoginUser objloginUser = new LoginUser();

        //    HttpContextAccessor.HttpContext.Session.SetObject("MySession", objloginUser);
        //  // var objloginUsers= HttpContextAccessor.HttpContext.Session.GetObject("MySession");

        //   // var objComplex = HttpContextAccessor.HttpContext.Session.GetObject("ComplexObject");
        //    return objloginUser;
        //}

        //public void GetSessions()
        //{

        //    var objComplex = HttpContextAccessor.HttpContext.Session.GetObject("ComplexObject");
        //}



        public class LoginUser
        {
            public int LoginId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Type { get; set; }
        }
    }
    public static class SessionExtensions
    {
        //public static void SetObject(this ISession session, string key, object value)
        //{
        //    session.SetString(key, JsonConvert.SerializeObject(value));
        //}

        //public static object GetObject(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null ? default(object) : JsonConvert.DeserializeObject(value);
        //}
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

    }

  
}
