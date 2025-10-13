using AutoMapper;
using BusinessLogic.DTOs.UserDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System.Net;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly CinemaDbContext db;
        private readonly IMapper mapper;

        public UserService(CinemaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Create(CreateUserDto model)
        {
            var user = mapper.Map<User>(model);

            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = db.Users.Find(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

        public async Task Edit(EditUserDto model)
        {
            var user = mapper.Map<User>(model);

            db.Users.Update(user);
            await db.SaveChangesAsync();
        }

        public async Task<IList<UserDto>> GetAll(string? UserName, int numberPage = 1)
        {
            IQueryable<User> users = db.Users;

            if (UserName != null)
            {
                users = db.Users
                    .Where(x => x.UserName.Contains(UserName.ToLower()));
            }

            var usersPaged = await PagedList<User>.CreateAsync(users, numberPage, 5);

            return mapper.Map<IList<UserDto>>(usersPaged);
        }

        public async Task<UserDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = await db.Users.FindAsync(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
