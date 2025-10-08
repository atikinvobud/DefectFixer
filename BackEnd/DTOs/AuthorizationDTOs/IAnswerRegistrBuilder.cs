namespace BackEnd.DTOs;

public interface IAnswerRegistrBuilder
{
    IAnswerRegistrBuilder SetUserId(int userId);
    IAnswerRegistrBuilder SetError(string error);
    AnswerRegistr Build();
}