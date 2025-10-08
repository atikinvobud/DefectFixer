namespace BackEnd.DTOs;

public record PostHistory
{
    public int DefectId { get; set; }
    public int NewStatusId { get; set; }
    public int UserId { get; set; }
}