using AutoMapper;
using BusinessLogic.DTOs.Accounts;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly CinemaDbContext db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJwtService jwtService;

        public AccountService(
            CinemaDbContext db,
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IMapper mapper,
            IJwtService jwtService
            )
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            Mapper = mapper;
            this.jwtService = jwtService;
        }

        public IMapper Mapper { get; }

        public async Task<LoginResponse> Login(LoginModel model, string? ipAddress)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email or password.", HttpStatusCode.BadRequest);

            var refreshToken = jwtService.GenerateRefreshToken(ipAddress ?? "unknown");
            user.RefreshTokens.Add(refreshToken);

            await db.SaveChangesAsync();

            return new()
            {
                AccessToken = jwtService.GenerateToken(jwtService.GetClaims(user)),
                RefreshToken = refreshToken.Token
            };
        }

        public async Task Logout(LogoutModel model)
        {
            await signInManager.SignOutAsync();
        }

        public async Task<LoginResponse> Refresh(RefreshRequest model, string? ipAddress)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == model.RefreshToken));
            if (user == null)
                throw new HttpException("Invalid user.", HttpStatusCode.Unauthorized);

            var token = db.RefreshTokens.Single(x => x.Token == model.RefreshToken);

            if (!token.IsActive)
                throw new HttpException("Invalid refresh token", HttpStatusCode.Unauthorized);

            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;

            var newJwt = jwtService.GenerateToken(jwtService.GetClaims(user));
            var newRefresh = jwtService.GenerateRefreshToken(ipAddress ?? "unknown");

            user.RefreshTokens.Add(newRefresh);

            await db.SaveChangesAsync();

            return new()
            {
                AccessToken = newJwt,
                RefreshToken = newRefresh.Token
            };
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
