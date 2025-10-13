using BusinessLogic.DTOs.Accounts;

namespace BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterModel model);
        Task<LoginResponse> Login(LoginModel model);
        Task Logout(LogoutModel model);
    }
}
