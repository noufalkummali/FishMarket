using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.ViewModel
{
    public class LoginVm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
