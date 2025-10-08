namespace BackEnd.DTOs;

public record PostComment
{
    public int Id { get; set; }
    public int DefectId { get; set; }
    public string Text { get; set; } = null!;
    public int AuthorId { get; set; }
}