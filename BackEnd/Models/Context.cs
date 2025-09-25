using BackEnd.Models.Entities;
using BackEnd.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public class Context : DbContext
{
    public DbSet<AplicationsEntity> Applications { get; set; } = null!;
    public DbSet<CommentEntity> Comments { get; set; } = null!;
    public DbSet<DefectEntity> Defects { get; set; } = null!;
    public DbSet<HistoryEntity> Histories { get; set; } = null!;
    public DbSet<PriorityEntity> Priorities { get; set; } = null!;
    public DbSet<ProjectEmployersEntity> ProjectEmployers { get; set; } = null!;
    public DbSet<ProjectEntity> Projects { get; set; } = null!;
    public DbSet<ReportEntity> Reports { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<StatusEntity> Statuses { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<UserInfoEntity> userInfos { get; set; } = null!;

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AplicationConfiguration());
        builder.ApplyConfiguration(new CommentConfiguration());
        builder.ApplyConfiguration(new DefectConfiguration());
        builder.ApplyConfiguration(new HistoryConfiguration());
        builder.ApplyConfiguration(new PriorityConfiguration());
        builder.ApplyConfiguration(new ProjectConfiguration());
        builder.ApplyConfiguration(new ProjectEmployersConfiguration());
        builder.ApplyConfiguration(new ReportConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new StatusConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserInfoConfiguration());

    }
}