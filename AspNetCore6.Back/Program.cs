using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Infrastructure.Tools;
using AspNetCore6.Back.Persistance.Contexts;
using AspNetCore6.Back.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

// Repository Service
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// CQRS MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// AutoMapper Profiles
builder.Services.AddAutoMapper(typeof(Program));

//CORS Configuration
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCORS", config =>
    {
        config.AllowAnyHeader().AllowAnyHeader().AllowAnyMethod();
    });
});

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.ValidAudience,
        ValidIssuer = JwtTokenSettings.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.IssuerSigningKey)),
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GlobalCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();