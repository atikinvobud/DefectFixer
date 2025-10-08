using BackEnd.DTOs;
using BackEnd.Services;
using BackEnd.Repositories;
using FluentValidation;
using BackEnd.Models;

namespace BackEnd.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAnswerLoginBuilder, AnswerLoginBuilder>();
        services.AddScoped<IAnswerRegistrBuilder, AnswerRegistrBuilder>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IMongoService, MongoService>();
        services.AddScoped<IPasswordHasher, PasswordHasherService>();
        services.AddScoped<AbstractValidator<RegistrDTO>, UserValidator>();
        services.AddScoped<AbstractValidator<ChangePassword>, PasswordValidator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMongoRepository, MongoRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IPasswordRecoveryService, PasswordRecoveryService>();
        services.AddScoped<IRecoveryCodeRepository, RedisRepository>();
        services.AddScoped<IPriorityRepository, PriorityRepository>();
        services.AddScoped<IPriorityService, PriorityService>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IHistoryRepository, HistoryRepository>();
        services.AddScoped<IHistoryService, HistoryService>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IApplicationRepository, ApplicationsRepository>();
        services.AddScoped<IPictureService, PictureService>();
        services.AddScoped<IChangePasswordService, ChangePasswordService>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddSingleton<MongoDbContext>();
        return services;
    }
}