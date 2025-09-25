using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Models.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.defectEntity)
            .WithMany(D => D.commentEntities)
            .HasForeignKey(C => C.DefectId);

        builder.HasOne(c => c.userEntity)
            .WithMany(u => u.commentEntities)
            .HasForeignKey(c => c.AuthorId);
    }
}