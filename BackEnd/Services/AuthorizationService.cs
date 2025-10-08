using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models;
using BackEnd.Models.Entities;
using BackEnd.Repositories;
using FluentValidation;
using Npgsql.TypeMapping;

namespace BackEnd.Services;

public class AuthorizationService : IAuthorizationService
{

    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher hashService;
    private readonly AbstractValidator<RegistrDTO> validator;
    private readonly IJwtService jwtService;
    public AuthorizationService(IUserRepository userRepository, IPasswordHasher hashService, AbstractValidator<RegistrDTO> validator, IJwtService jwtService)
    {
        this.userRepository = userRepository;
        this.hashService = hashService;
        this.validator = validator;
        this.jwtService = jwtService;
    }

    public async Task<AnswerRegistr> RegistrUser(RegistrDTO registrDTO)
    {
        var answer = new AnswerRegistrBuilder();
        List<UserEntity> users = await userRepository.GetAllUsers();
        if (users.Where(u => u.Login == registrDTO.Login).Count() == 0)
        {
            var result = await validator.ValidateAsync(registrDTO);
            if (!result.IsValid)
            {
                answer.SetError(result.Errors[0].ErrorMessage);
                return answer.Build();
            }
            registrDTO.Password = hashService.HashPassword(registrDTO.Password);
            UserEntity user = registrDTO.ToEntity();
            int id = await userRepository.CreateUser(user);
            UserInfoEntity userInfo = registrDTO.ToInfoEntity(id);
            await userRepository.CreateUserInfo(userInfo);
            answer.SetUserId(id);
            return answer.Build();
        }
        answer.SetError("ВВеден не уникальный логин");
        return answer.Build();
    }

    public async Task<AnswerLoginDTO> Login(LoginDTO loginDTO)
    {
        var answer = new AnswerLoginBuilder();
        UserEntity? user = await userRepository.GetUserByLogin(loginDTO.Login);
        if (user == null)
        {
            answer.SetError("Не найден такой логин");
            return answer.Build();
        }
        if (!hashService.VerifyPassword(user!.HashPassword, loginDTO.Password))
        {
            answer.SetError("Введен неправильный пароль");
            return answer.Build();
        }
        string token = jwtService.GenerateToken(user);
        string coockieName = jwtService.GetCoockieName();
        int expireHours = jwtService.GetExpireHours();

        answer.SetUserId(user.Id).SetRoleId(user.RoleId).SetToken(token).SetCoockieName(coockieName).SetExpireHours(expireHours);
        return answer.Build();
    }

    public async Task<bool> ChangePassword(string login, string newPassword)
    {
        UserEntity? user = await userRepository.GetUserByLogin(login);
        if (user == null) return false;
        newPassword = hashService.HashPassword(newPassword);
        await userRepository.UpdateUser(user, newPassword);
        return true;
    }
}