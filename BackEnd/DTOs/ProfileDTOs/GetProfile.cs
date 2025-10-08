namespace BackEnd.DTOs;

public record GetProfile
{
    public string Name { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public string Email { get; set; } = null!;
}