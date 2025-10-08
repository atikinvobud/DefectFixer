namespace BackEnd.DTOs;

public record PutHistory
{
    public int Id { get; set; }
    public int? DefectId { get; set; }
    public int? NewStatusId { get; set; }
    public int? UserId { get; set; }
}