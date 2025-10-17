using BusinessLogic.DTOs.UserDto;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Cinema_Api.Helpers;

namespace Project_Cinema_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(string? UserName, int numberPage = 1)
        {
            return Ok(await userService.GetAll(UserName, numberPage));
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            return Ok(await userService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(CreateUserDto createUser)
        {
            await userService.Create(createUser);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Edit(EditUserDto editUser)
        {
            await userService.Edit(editUser);

            return Ok();
        }

        [Authorize(Roles = Roles.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            await userService.Delete(id);

            return NoContent();
        }
    }
}
