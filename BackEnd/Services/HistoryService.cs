using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository historyRepository;
    public HistoryService(IHistoryRepository historyRepository)
    {
        this.historyRepository = historyRepository;
    }

    public async Task<int> Create(PostHistory postHistory)
    {
        HistoryEntity history = postHistory.ToEntity();
        int id = await historyRepository.CreateHistory(history);
        return id;
    }
    public async Task<bool> Delete(DeleteHistory deleteHistory)
    {
        HistoryEntity? history = await historyRepository.GetEntityById(deleteHistory.Id);
        if (history == null) return false;
        await historyRepository.DeleteHistory(history);
        return true;
    }
    public async Task<bool> Update(PutHistory putHistory)
    {
        HistoryEntity? history = await historyRepository.GetEntityById(putHistory.Id);
        if (history == null) return false;
        history.Update(putHistory);
        await historyRepository.UpdateHistory(history);
        return true;
    }
    public async Task<GetHistory?> GetById(int id)
    {
        HistoryEntity? history = await historyRepository.GetEntityById(id);
        if (history == null) return null;
        return history.ToDTO();
    }
    public async Task<List<GetHistory>> GetAll()
    {
        List<HistoryEntity> histories = await historyRepository.GetAllHistory();
        List<GetHistory> dtos = new List<GetHistory>();
        foreach (HistoryEntity history in histories)
        {
            dtos.Add(history.ToDTO());
        }
        return dtos;
    }
    public async Task<List<GetHistory>> GetByDefectId(int defectId)
    {
        List<HistoryEntity> histories = await historyRepository.GetHistoryByDefect(defectId);
        List<GetHistory> dtos = new List<GetHistory>();
        foreach (HistoryEntity history in histories)
        {
            dtos.Add(history.ToDTO());
        }
        return dtos;
    }
}