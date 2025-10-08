namespace BackEnd.DTOs;

public class AnswerLoginBuilder : IAnswerLoginBuilder
{
    private AnswerLoginDTO answerLoginDTO = new();

    public IAnswerLoginBuilder SetUserId(int userId)
    {
        answerLoginDTO.UserId = userId;
        return this;
    }

    public IAnswerLoginBuilder SetRoleId(int roleId)
    {
        answerLoginDTO.RoleId = roleId;
        return this;
    }

    public IAnswerLoginBuilder SetToken(string token)
    {
        answerLoginDTO.Token = token;
        return this;
    }

    public IAnswerLoginBuilder SetExpireHours(int expireHours)
    {
        answerLoginDTO.ExpireHours = expireHours;
        return this;
    }

    public IAnswerLoginBuilder SetError(string error)
    {
        answerLoginDTO.Error = error;
        return this;
    }

    public IAnswerLoginBuilder SetCoockieName(string coockieName)
    {
        answerLoginDTO.CoockieName = coockieName;
        return this;
    }
    public AnswerLoginDTO Build()
    {
        AnswerLoginDTO result = answerLoginDTO;
        answerLoginDTO = new AnswerLoginDTO();
        return result;
    }
}