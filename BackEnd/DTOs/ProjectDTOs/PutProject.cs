namespace BackEnd.DTOs;

public record PutProject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
}