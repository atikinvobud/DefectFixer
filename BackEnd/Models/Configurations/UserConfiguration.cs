using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.roleEntity)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder.HasOne(u => u.UserInfoEntity)
            .WithOne(ui => ui.user);

        builder.HasMany(u => u.aplicationsEntities)
            .WithOne(a => a.user);

        builder.HasMany(u => u.projectEmployersEntities)
            .WithOne(u => u.userEntity);

        builder.HasMany(u => u.historyEntities)
            .WithOne(h => h.userEntity);

        builder.HasMany(u => u.commentEntities)
            .WithOne(c => c.userEntity);

        builder.HasMany(u => u.AuthorDefects)
            .WithOne(d => d.author);

        builder.HasMany(u => u.ExecutorDefects)
            .WithOne(d => d.engeneer);
    }
}