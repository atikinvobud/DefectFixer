using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfoEntity>
{
    public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
    {
        builder.HasKey(ui => ui.Id);

        builder.HasOne(ui => ui.user)
            .WithOne(u => u.UserInfoEntity)
            .HasForeignKey<UserInfoEntity>(ui => ui.Id);
    }
}