using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class PriorityService : IPriorityService
{
    private readonly IPriorityRepository priorityRepository;
    public PriorityService(IPriorityRepository priorityRepository)
    {
        this.priorityRepository = priorityRepository;
    }

    public async Task<int> Create(PostPriority postPriority)
    {
        PriorityEntity priority = postPriority.ToEntity();
        int id = await priorityRepository.CreatePriority(priority);
        return id;
    }
    public async Task<bool> Delete(DeletePriority deletePriority)
    {
        PriorityEntity? priority = await priorityRepository.GetEntityById(deletePriority.Id);
        if (priority == null) return false;
        await priorityRepository.DeletePriority(priority);
        return true;
    }
    public async Task<bool> Update(PutPriority putPriority)
    {
        PriorityEntity? priority = await priorityRepository.GetEntityById(putPriority.Id);
        if (priority == null) return false;
        priority.Update(putPriority);
        await priorityRepository.UpdatePriority(priority);
        return true;
    }
    public async Task<GetPriority?> GetById(int id)
    {
        PriorityEntity? priority = await priorityRepository.GetEntityById(id);
        if (priority == null) return null;
        return priority.ToDTO();
    }
    public async Task<List<GetPriority>> GetAll()
    {
        List<PriorityEntity> priorities = await priorityRepository.GetAllPriorities();
        List<GetPriority> dtos = new List<GetPriority>();
        foreach (PriorityEntity priority in priorities)
        {
            dtos.Add(priority.ToDTO());
        }
        return dtos;
    }
}