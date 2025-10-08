using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly Context context;
    public ProfileRepository(Context context)
    {
        this.context = context;
    }

    public async Task<UserInfoEntity?> GetProfile(int userId)
    {
        return await context.userInfos.Where(u => u.Id == userId).Include(u => u.user!).ThenInclude(u => u.roleEntity!).FirstOrDefaultAsync();
    }
    public async Task UpdateProfile()
    {
        await context.SaveChangesAsync();
    }
}