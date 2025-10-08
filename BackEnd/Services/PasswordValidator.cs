using BackEnd.DTOs;
using FluentValidation;

namespace BackEnd.Services;

public class PasswordValidator : AbstractValidator<ChangePassword>
{
    public PasswordValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(dto => dto.LatePassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Пароль не должен быть пустым")
            .MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов");

        RuleFor(dto => dto.NewPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Пароль не должен быть пустым")
            .MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов");

        RuleFor(dto => dto.RepeatNewPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Пароль не должен быть пустым")
            .MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов");

        RuleFor(dto => dto)
            .Cascade(CascadeMode.Stop)
            .Must(dto => dto.NewPassword == dto.RepeatNewPassword).WithMessage("Пароли не совпадают");
    }
}