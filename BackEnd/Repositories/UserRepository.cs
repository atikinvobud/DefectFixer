using System.Drawing;
using System.Runtime.CompilerServices;
using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context context;
    public UserRepository(Context context)
    {
        this.context = context;
    }

    public async Task<int> CreateUser(UserEntity userEntity)
    {
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
        return userEntity.Id;
    }

    public async Task CreateUserInfo(UserInfoEntity userInfoEntity)
    {
        var exists = await context.userInfos.AnyAsync(ui => ui.Id == userInfoEntity.Id);
        if (exists)
        {
            context.Attach(userInfoEntity);
            context.Entry(userInfoEntity).State = EntityState.Modified;
        }
        else await context.userInfos.AddAsync(userInfoEntity);
        await context.SaveChangesAsync();
    }
    public async Task<UserEntity?> GetUserById(int userId)
    {
        UserEntity? userEntity = await context.Users.Include(u => u.roleEntity).FirstOrDefaultAsync(u => u.Id == userId);
        if (userEntity == null) return null;
        return userEntity;
    }

    public async Task<UserEntity?> GetUserByLogin(string login)
    {
        UserEntity? userEntity = await context.Users.FirstOrDefaultAsync(u => u.Login == login);
        if (userEntity == null) return null;
        return userEntity;
    }

    public async Task<List<UserEntity>> GetAllUsers()
    {
        return await context.Users.ToListAsync();
    }

    public async Task UpdateUser(UserEntity user, string newPassword)
    {
        user.HashPassword = newPassword;
        await context.SaveChangesAsync();
    }
    public async Task Update()
    {
        await context.SaveChangesAsync();
    }
}