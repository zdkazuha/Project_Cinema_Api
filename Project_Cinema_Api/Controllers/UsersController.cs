using AutoMapper;
using BusinessLogic.DTOs.UserDto;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Cinema_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public UsersController(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetUsers()
        {
            var users = db.Users.ToList();

            var usersDto = mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userDto = mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(createUser);

            db.Users.Add(user);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EditUserDto editUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(editUser);

            db.Users.Update(user);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok();
        }
    }
}
