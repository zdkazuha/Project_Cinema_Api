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
        private readonly SignInManager<User> signInManager;
        private readonly IJwtService jwtService;

        public AccountService(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IMapper mapper,
            IJwtService jwtService
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            Mapper = mapper;
            this.jwtService = jwtService;
        }

        public IMapper Mapper { get; }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email or password.", HttpStatusCode.BadRequest);

            //await signInManager.SignInAsync(user, true);

            return new()
            {
                AccessToken = jwtService.GenerateToken(jwtService.GetClaims(user))
            };
        }

        public async Task Logout(LogoutModel model)
        {
            await signInManager.SignOutAsync();
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
