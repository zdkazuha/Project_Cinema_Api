using BusinessLogic.DTOs.Accounts;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private string? CurrentIp => HttpContext.Connection.RemoteIpAddress?.ToString();

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await accountService.Register(model);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var res = await accountService.Login(model, CurrentIp);

            return Ok(res);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutModel model)
        {
            await accountService.Logout(model);

            return Ok();
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest refreshRequest)
        {
            return Ok(await accountService.Refresh(refreshRequest, CurrentIp));
        }
    }
}
