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
                .HasMaxLength(200)
                .HasColumnType("NVARCHAR");
            builder.Property(p => p.ASCII)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR")
                .IsRequired(false); 
            builder.Property(p => p.KeyWords)
                .HasMaxLength(100)
                .HasColumnType("NVARCHAR")
                .IsRequired(false);
            builder.Property(p => p.Links)
                .HasMaxLength(100)
                .HasColumnType("NVARCHAR")
                .IsRequired(false);
            builder.Property(p => p.CreatedAt)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.HasMany(p => p.Comments)
                   .WithOne()
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
