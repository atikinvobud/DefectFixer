namespace BackEnd.Models.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public required DateOnly CreatedAt { get; set; }
    public required string Name { get; set; }
    public List<ProjectEmployersEntity> projectEmployersEntities { get; set; } = new List<ProjectEmployersEntity>();
    public List<DefectEntity> defectEntities { get; set; } = new List<DefectEntity>();
    public List<ReportEntity> reportEntities{ get; set; }= new List<ReportEntity>();

}