using BusinessLogic.Configurations;
using BusinessLogic.DTOs.Jwt;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Validators.Create;
using DataAccess.Data;
using DataAccess.Data.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project_Cinema_Api;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("ConnStr") ?? throw new InvalidOperationException("No Connection String found.");
//string someeStr = builder.Configuration.GetConnectionString("SomeeStr") ?? throw new InvalidOperationException("No Connection String found.");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateMovieDtoValidator>();

builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<CinemaDbContext>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMovieActorService, MovieActorService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddSingleton(_ => builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!);
var jwtOpts = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

builder.Services.AddJWTSettings(jwtOpts);
builder.Services.AddSwaggerWithJWT();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
