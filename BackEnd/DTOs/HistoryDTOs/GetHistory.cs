using System.Reflection.Metadata;

namespace BackEnd.DTOs;

public record GetHistory
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = null!;
}