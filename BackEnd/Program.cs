using System.Text;
using System.Text.Json;
using BackEnd.Extentions;
using BackEnd.Models;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using StackExchange.Redis;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

//добавление DI контейнеров 
builder.Services.AddServices();

//добавление переменных окружения в appsettings
builder.Configuration.AddEnvironmentVariables();

//настройка контроллеров
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = false;
    });

//подключеник к PostGreSQL
var connectionString =Environment.GetEnvironmentVariable("DatabaseConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

//подключение к монго
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING")
                           ?? throw new Exception("MONGO_CONNECTION_STRING not set");
    return new MongoClient(connectionString);
});

// Подключение к Redis через ConnectionMultiplexer
builder.Services.AddSingleton<IConnectionMultiplexer>(_ => 
    ConnectionMultiplexer.Connect("localhost:6379"));
    
//получение JwtSettings 
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

//подключение сваггера часть 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "DefectFixer",
        Version = "v1"
    });
});

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("JwtSettings:SecretKey")!
            )),

            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],

            ValidateLifetime = true,
        };

        string cookieName = builder.Configuration["JwtSettings:CoockieName"]!;
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies[cookieName];
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

//подключение сваггера часть 2
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

});

// автоматическое применение миграций
app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//настройка контроллеров
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

