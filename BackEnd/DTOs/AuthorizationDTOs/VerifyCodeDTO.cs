namespace BackEnd.DTOs;

public record VerifyCodeDto
{
    public string Email { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}