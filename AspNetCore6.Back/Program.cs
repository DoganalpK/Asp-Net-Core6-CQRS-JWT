using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Persistance.Contexts;
using AspNetCore6.Back.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
