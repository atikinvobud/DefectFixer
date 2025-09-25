using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Users)
            .WithOne(u => u.roleEntity);
    }
}