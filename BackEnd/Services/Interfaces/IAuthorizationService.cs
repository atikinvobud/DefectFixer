using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IAuthorizationService
{
    Task<AnswerRegistr> RegistrUser(RegistrDTO registrDTO);
    Task<AnswerLoginDTO> Login(LoginDTO loginDTO);
    Task<bool> ChangePassword(string login, string newPassword);
}