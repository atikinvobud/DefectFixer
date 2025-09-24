namespace BackEnd.Models.Entities;

public class ProjectEmployersEntity
{
    public int Id { get; set; }
    public required int ProjectId { get; set; }
    public required int UserId { get; set; }
    public UserEntity? userEntity { get; set; }
    public ProjectEntity? projectEntity{ get; set; }
}
