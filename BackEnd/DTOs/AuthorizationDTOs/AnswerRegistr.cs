namespace BackEnd.DTOs;

public record AnswerRegistr
{
    public int UserId { get; set; } = 0;
    public string Error { get; set; } = string.Empty;
}