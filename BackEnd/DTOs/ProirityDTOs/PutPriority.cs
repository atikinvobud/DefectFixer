namespace BackEnd.DTOs;

public record PutPriority
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}