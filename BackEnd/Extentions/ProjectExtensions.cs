using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class ProjectExtensions
{
    public static ProjectEntity ToEntity(this PostProject postProject)
    {
        return new ProjectEntity()
        {
            Name = postProject.Name,
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow)
        };
    }
    public static void Update(this ProjectEntity entity, PutProject putProject)
    {
        entity.Name = putProject.Name ?? entity.Name;
    }
    public static ProjectEmployersEntity ApplyUser(this AddUser addUser)
    {
        return new ProjectEmployersEntity()
        {
            ProjectId = addUser.ProjectId,
            UserId = addUser.UserId
        };
    }
    public static GetBaseProject ToBaseDTO(this ProjectEntity entity)
    {
        return new GetBaseProject()
        {
            Id = entity.Id,
            Name = entity.Name,
            CreatedAt = entity.CreatedAt,
            ActiveDefects = entity.defectEntities.Count(d => d.statusEntity!.Name != "Closed")
        };
    }
    public static GetExtendedProject ToExtendedDTO(this ProjectEntity entity)
    {
        return new GetExtendedProject()
        {
            Id = entity.Id,
            DefectAmount = entity.defectEntities.Count(),
            ActiveDefects = entity.defectEntities.Count(d => d.statusEntity!.Name != "Closed"),
            CriticalDefects = entity.defectEntities.Count(d => d.statusEntity!.Name == "Critical"),
            Name = entity.Name,
            ManagerNames = entity.projectEmployersEntities.Where(pu => pu.userEntity!.roleEntity!.Name == "Manager").Select(pu => $"{pu.userEntity!.UserInfoEntity!.Name} {pu.userEntity.UserInfoEntity.Surname}").ToList()
        };
    }
}