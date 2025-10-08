using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IProjectService
{
    Task<int> Create(PostProject postProject);
    Task<bool> Delete(DeleteProject deleteProject);
    Task<List<GetBaseProject>> GetAllBase(int userId);
    Task<List<GetExtendedProject>> GetAllExtended(int userId);
    Task<bool> Update(PutProject putProject);
    Task<int> ApplyUser(AddUser user);
}