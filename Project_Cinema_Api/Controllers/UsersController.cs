using BusinessLogic.DTOs.UserDto;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
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
        public IActionResult GetUsers(string? UserName)
        {
            return Ok(userService.GetAll(UserName));
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto createUser)
        {
            userService.Create(createUser);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditUserDto editUser)
        {
            userService.Edit(editUser);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);

            return NoContent();
        }
    }
}
