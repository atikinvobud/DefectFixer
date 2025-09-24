namespace BackEnd.Models.Entities;

public class CommentEntity
{
    public int Id { get; set; }
    public required int DefectId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required string Text { get; set; }
    public required int AuthorId { get; set; }
    public UserEntity? userEntity { get; set; }
    public DefectEntity? defectEntity{ get; set; }
}