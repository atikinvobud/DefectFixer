using BackEnd.Models.Entities;

namespace BackEnd.Repositories;

public interface IApplicationRepository
{
    Task<List<AplicationsEntity>> GetPhotoByDefect(int defectId);
    Task<int> CretePhato(AplicationsEntity aplicationsEntity);
}