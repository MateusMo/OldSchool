using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldSchoolDomain.Domain;

namespace OldSchoolDomain.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostDomain>
    {
        public void Configure(EntityTypeBuilder<PostDomain> builder)
        {
            builder.ToTable("Posts"); 
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); 

            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("NVARCHAR");

            builder.Property(p => p.MindsetId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(u => u.UpdatedAt)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.HasMany(p => p.Comments)
                   .WithOne()
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
