namespace BackEnd.DTOs;

public record ChangePassword
{
    public string LatePassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!; 
    public string RepeatNewPassword { get; set; } = null!;
}