using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository projectRepository;
    public ProjectService(IProjectRepository projectRepository)
    {
        this.projectRepository = projectRepository;
    }
    public async Task<int> Create(PostProject postProject)
    {
        ProjectEntity entity = postProject.ToEntity();
        int id = await projectRepository.CreateProject(entity);
        return id;
    }
    public async Task<bool> Delete(DeleteProject deleteProject)
    {
        ProjectEntity? project = await projectRepository.GetById(deleteProject.Id);
        if (project == null) return false;
        await projectRepository.DeleteProject(project);
        return true;
    }
    public async Task<bool> Update(PutProject putProject)
    {
        ProjectEntity? project = await projectRepository.GetById(putProject.Id);
        if (project == null) return false;
        project.Update(putProject);
        await projectRepository.UpdateProject();
        return true;
    }
    public async Task<int> ApplyUser(AddUser user)
    {
        ProjectEmployersEntity entity = user.ApplyUser();
        int id = await projectRepository.ApplyUser(entity);
        return id;
    }
    public async Task<List<GetBaseProject>> GetAllBase(int userId)
    {
        List<ProjectEntity> projects = await projectRepository.GetProjects(userId);
        List<GetBaseProject> dtos = new List<GetBaseProject>();
        foreach (ProjectEntity project in projects)
        {
            dtos.Add(project.ToBaseDTO());
        }
        return dtos;
    }
    public async Task<List<GetExtendedProject>> GetAllExtended(int userId)
    {
        List<ProjectEntity> projects = await projectRepository.GetProjects(userId);
        List<GetExtendedProject> dtos = new List<GetExtendedProject>();
        foreach (ProjectEntity project in projects)
        {
            dtos.Add(project.ToExtendedDTO());
        }
        return dtos;
    }
}