using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class HistotyExtensions
{
    public static GetHistory ToDTO(this HistoryEntity history)
    {
        return new GetHistory()
        {
            Id = history.Id,
            CreatedAt = history.CreatedAt,
            Text = " Инженер " + history.userEntity!.UserInfoEntity!.Name + " " + history.userEntity!.UserInfoEntity!.Surname + "изменил статус на " + history.statusEntity!.Name
        };
    }
    public static HistoryEntity ToEntity(this PostHistory postHistory)
    {
        return new HistoryEntity()
        {
            DefectId = postHistory.DefectId,
            NewStatusId = postHistory.NewStatusId,
            UserId = postHistory.UserId,
            CreatedAt = DateTime.Now
        };
    }
    public static void Update(this HistoryEntity entity, PutHistory putHistory)
    {
        entity.DefectId = putHistory.DefectId ?? entity.DefectId;
        entity.NewStatusId = putHistory.NewStatusId ?? entity.NewStatusId;
        entity.UserId = putHistory.UserId ?? entity.UserId;
        entity.CreatedAt = DateTime.Now;  
    }
}