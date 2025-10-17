using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.Accounts
{
    public class LoginModel
    {
        [DefaultValue("artem@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("A123321a*")]
        public string Password { get; set; }
    }
}
