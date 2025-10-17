using AutoMapper;
using BusinessLogic.DTOs.UserDto;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using System.Net;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repo;
        private readonly IMapper mapper;

        public UserService(IRepository<User> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task Create(CreateUserDto model)
        {
            var user = mapper.Map<User>(model);

            if(user == null)
                throw new HttpException("User is null ", HttpStatusCode.BadRequest);

            await repo.AddAsync(user);
        }

        public async Task Delete(int id)
        {
            if (id < 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = repo.GetByIdAsync(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            await repo.DeleteAsync(id);
        }

        public async Task Edit(EditUserDto model)
        {
            var user = mapper.Map<User>(model);

            await repo.UpdateAsync(user);
        }

        public async Task<IList<UserDto>> GetAll(string? UserName, int numberPage = 1)
        {
            var users = await repo.GetAllAsync(numberPage, 5);

            return mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto?> Get(int id)
        {
            if (id <= 0)
                throw new HttpException("Id can`t be negative ", HttpStatusCode.BadRequest);

            var user = await repo.GetByIdAsync(id);

            if (user == null)
                throw new HttpException($"User with id-{id} not found ", HttpStatusCode.NotFound);

            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
