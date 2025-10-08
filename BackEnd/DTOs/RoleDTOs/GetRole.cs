namespace BackEnd.DTOs;

public record GetRole
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}