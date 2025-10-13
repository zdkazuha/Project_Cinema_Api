using BusinessLogic.DTOs.Accounts;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

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
            var res = await accountService.Login(model);

            return Ok(res);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutModel model)
        {
            await accountService.Logout(model);

            return Ok();
        }
    }
}
