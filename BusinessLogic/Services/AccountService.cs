using AutoMapper;
using BusinessLogic.DTOs.Accounts;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;

        public AccountService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public Task Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task Logout(LogoutModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Register(RegisterModel model)
        {
            var user = Mapper.Map<User>(model);

            var result = await userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                throw new HttpException(result.Errors?.FirstOrDefault()?.Description ?? "Error", HttpStatusCode.BadRequest);
            }
        }
    }
}
