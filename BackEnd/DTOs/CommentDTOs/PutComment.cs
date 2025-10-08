namespace BackEnd.DTOs;

public record PutComment
{
    public int? Id { get; set; }
    public int? DefectId { get; set; }
    public string? Text { get; set; }
    public int? AuthorId { get; set; }
}