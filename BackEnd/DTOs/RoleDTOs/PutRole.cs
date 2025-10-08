namespace BackEnd.DTOs;

public record PutRole
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}