using AutoMapper;
using BusinessLogic.DTOs.UserDto;
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

        public void Create(CreateUserDto model)
        {
            var user = mapper.Map<User>(model);

            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = db.Users.Find(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Edit(EditUserDto model)
        {
            var user = mapper.Map<User>(model);

            db.Users.Update(user);
            db.SaveChanges();
        }

        public IList<UserDto> GetAll()
        {
            var users = db.Users.ToList();

            var usersDto = mapper.Map<IList<UserDto>>(users);

            return usersDto;
        }

        public UserDto? Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = db.Users.Find(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
