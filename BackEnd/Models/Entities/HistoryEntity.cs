namespace BackEnd.Models.Entities;

public class HistoryEntity
{
    public int Id { get; set; }
    public required int DefectId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required int NewStatusId { get; set; }
    public required int UserId { get; set; }
    public UserEntity? userEntity { get; set; }
    public StatusEntity? statusEntity { get; set; }
    public DefectEntity? defectEntity { get; set; }
}