namespace BackEnd.DTOs;

public interface IAnswerLoginBuilder
{
    IAnswerLoginBuilder SetUserId(int userId);
    IAnswerLoginBuilder SetRoleId(int roleId);
    IAnswerLoginBuilder SetToken(string token);
    IAnswerLoginBuilder SetExpireHours(int expireHours);
    IAnswerLoginBuilder SetCoockieName(string coockieName);
    IAnswerLoginBuilder SetError(string error);
    AnswerLoginDTO Build();
}