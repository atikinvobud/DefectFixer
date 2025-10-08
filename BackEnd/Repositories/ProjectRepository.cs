using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly Context context;
    public ProjectRepository(Context context)
    {
        this.context = context;
    }

    public async Task<int> CreateProject(ProjectEntity project)
    {
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
        return project.Id;
    }
    public async Task UpdateProject()
    {
        await context.SaveChangesAsync();
    }
    public async Task DeleteProject(ProjectEntity project)
    {
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
    }
    public async Task<int> ApplyUser(ProjectEmployersEntity employer)
    {
        await context.ProjectEmployers.AddAsync(employer);
        await context.SaveChangesAsync();
        return employer.Id;
    }
    public async Task<List<ProjectEntity>> GetProjects(int userId)
    {
        return await context.Projects.Include(p => p.projectEmployersEntities).ThenInclude(pe => pe.userEntity).ThenInclude(u => u!.roleEntity)
            .Include(u => u.defectEntities).ThenInclude(d => d.statusEntity).Include(p => p.projectEmployersEntities)
            .ThenInclude(pe => pe.userEntity).ThenInclude(u => u!.UserInfoEntity).Where(p => p.projectEmployersEntities.Any(pe => pe.UserId == userId)).ToListAsync();
    }
    public async Task<ProjectEntity?> GetById(int projectId)
    {
        return await context.Projects.Where(p => p.Id == projectId).FirstOrDefaultAsync();
    }
}