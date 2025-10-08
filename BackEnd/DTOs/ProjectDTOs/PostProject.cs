namespace BackEnd.DTOs;

public record PostProject
{
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}