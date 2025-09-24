namespace BackEnd.Models.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string HashPassword { get; set; }
    public required int RoleId { get; set; }

    public UserInfoEntity? UserInfoEntity { get; set; }
    public RoleEntity? roleEntity { get; set; }
    public List<AplicationsEntity> aplicationsEntities { get; set; } = new List<AplicationsEntity>();
    public List<ProjectEmployersEntity> projectEmployersEntities { get; set; } = new List<ProjectEmployersEntity>();
    public List<HistoryEntity> historyEntities { get; set; } = new List<HistoryEntity>();
    public List<CommentEntity> commentEntities { get; set; } = new List<CommentEntity>();
    public List<DefectEntity> AuthorDefects { get; set; } = new List<DefectEntity>();
    public List<DefectEntity> ExecutorDefects { get; set; } = new List<DefectEntity>();
    

}
