using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Repositories;

public interface IProjectRepository
{
    Task<int> CreateProject(ProjectEntity project);
    Task UpdateProject();
    Task DeleteProject(ProjectEntity project);
    Task<List<ProjectEntity>> GetProjects(int userId);
    Task<int> ApplyUser(ProjectEmployersEntity employer);
    Task<ProjectEntity?> GetById(int projectId);
}