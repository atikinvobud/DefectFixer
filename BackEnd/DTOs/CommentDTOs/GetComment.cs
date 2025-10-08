namespace BackEnd.DTOs;

public record GetComment
{
    public int Id { get; set; }
    public int DefectId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = null!;
    public string FullName { get; set; } = null!;
}