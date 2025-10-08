namespace BackEnd.DTOs;

public class AnswerRegistrBuilder : IAnswerRegistrBuilder
{
    private AnswerRegistr answerRegistr = new();

    public IAnswerRegistrBuilder SetUserId(int userId)
    {
        answerRegistr.UserId = userId;
        return this;
    }
    public IAnswerRegistrBuilder SetError(string error)
    {
        answerRegistr.Error = error;
        return this;
    }
    public AnswerRegistr Build()
    {
        AnswerRegistr result = answerRegistr;
        answerRegistr = new AnswerRegistr();
        return result;
    }
}