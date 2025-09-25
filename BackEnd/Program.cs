using BackEnd.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//подключеник к PostGreSQL
var connectionString =Environment.GetEnvironmentVariable("DatabaseConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

