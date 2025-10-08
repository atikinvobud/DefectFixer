namespace BackEnd.DTOs;

public record GetPriority
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}