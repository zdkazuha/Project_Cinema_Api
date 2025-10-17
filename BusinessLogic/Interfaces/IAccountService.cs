using BusinessLogic.DTOs.Accounts;

namespace BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterModel model);
        Task<LoginResponse> Login(LoginModel model, string? ipAddress);
        Task Logout(LogoutModel model);
        Task<LoginResponse> Refresh(RefreshRequest refreshRequest, string? ipAddress);
    }
}
