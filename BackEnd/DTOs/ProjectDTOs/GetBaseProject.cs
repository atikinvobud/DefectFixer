namespace BackEnd.DTOs;

public record GetBaseProject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly CreatedAt { get; set; }
    public int ActiveDefects { get; set; }
}