using System.ComponentModel;

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
