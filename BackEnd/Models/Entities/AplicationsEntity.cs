namespace BackEnd.Models.Entities;

public class AplicationsEntity
{
    public int Id { get; set; }
    public required int DefectId { get; set; }
    public required int UploadedById { get; set; }
    public required string FileName { get; set; }
    public required DateTime UploadedAt { get; set; }
    public required string MongoPictureId { get; set; }
    public UserEntity? user { get; set; }
    public DefectEntity? defect { get; set; }
}