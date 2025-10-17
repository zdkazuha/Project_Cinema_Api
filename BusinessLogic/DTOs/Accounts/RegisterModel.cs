namespace BusinessLogic.DTOs.Accounts
{
    public class RegisterModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string Country { get; set; }
    }
}
