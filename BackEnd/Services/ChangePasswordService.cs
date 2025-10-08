using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Repositories;
using FluentValidation;
using Sprache;

namespace BackEnd.Services;

public class ChangePasswordService : IChangePasswordService
{
    private readonly IUserRepository userRepository;
    private readonly AbstractValidator<ChangePassword> validator;
    private readonly IPasswordHasher passwordHasher;
    public ChangeAnswer dto;
    public ChangePasswordService(IUserRepository userRepository, AbstractValidator<ChangePassword> validator,IPasswordHasher passwordHasher)
    {
        this.userRepository = userRepository;
        this.validator = validator;
        this.passwordHasher = passwordHasher;
        dto = new ChangeAnswer();
    }
    public async Task<ChangeAnswer> ChangePassword(ChangePassword changePassword, int userId)
    {
        var entity = await userRepository.GetUserById(userId);
        if (entity == null)
        {
            dto.Error = "Не найден пользователь";
            return dto;
        }
        var result = await validator.ValidateAsync(changePassword);
        if (!result.IsValid)
        {
            dto.Error = result.Errors[0].ErrorMessage;
            return dto;
        }
        if (!passwordHasher.VerifyPassword(entity.HashPassword, changePassword.LatePassword))
        {
            dto.Error = "Неправильный пароль";
            return dto;
        }
        changePassword.NewPassword = passwordHasher.HashPassword(changePassword.NewPassword);
        entity.UpdatePassword(changePassword);
        await userRepository.Update();
        dto.IsSuccess = true;
        return dto;
    }
}