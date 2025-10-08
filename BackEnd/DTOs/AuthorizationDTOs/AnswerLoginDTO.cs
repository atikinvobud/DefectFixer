namespace BackEnd.DTOs;

public record AnswerLoginDTO
{
    public int UserId { get; set; } = 0;
    public int RoleId { get; set; } = 0;
    public string Token { get; set; } = string.Empty;
    public string CoockieName { get; set; } = string.Empty;
    public int ExpireHours { get; set; } = 0;
    public string Error { get; set; } = string.Empty;
}