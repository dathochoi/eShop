using System;
using System.Collections.Generic;
using System.Text;

namespace eShopViewModel.System.User
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememeberMe { get; set; }
    }
}
