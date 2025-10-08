using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly Context context;
    public CommentRepository(Context context)
    {
        this.context = context;
    }

    public async Task<List<CommentEntity>> GetAllComments()
    {
        return await context.Comments.Include(c => c.userEntity).ThenInclude(u => u!.UserInfoEntity).ToListAsync();
    }
    public async Task<List<CommentEntity>> GetCommentsByDefect(int defectId)
    {
        return await context.Comments.Where(c => c.DefectId == defectId).Include(c => c.userEntity)
                .ThenInclude(u => u!.UserInfoEntity).ToListAsync();
    }
    public async Task<CommentEntity?> GetEntityById(int id)
    {
        return await context.Comments.Include(c => c.userEntity).ThenInclude(u => u!.UserInfoEntity).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<int> CreateComment(CommentEntity comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return comment.Id;
    }
    public async Task UpdateComment(CommentEntity comment)
    {
        context.Comments.Update(comment);
        await context.SaveChangesAsync();
    }
    public async Task DeleteComment(CommentEntity comment)
    {
        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
    }
}