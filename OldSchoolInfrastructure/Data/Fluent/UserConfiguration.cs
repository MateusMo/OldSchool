using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldSchoolDomain.Domain;

namespace OldSchoolDomain.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.ToTable("Users"); // Nome da tabela
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); // Geração automática de ID

            builder.Property(u => u.Nickname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR");

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR");

            builder.Property(u => u.LastLogin)
                .IsRequired()
                .HasColumnType("DateTime");


            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(u => u.UpdatedAt)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.HasMany(u => u.Posts)
                   .WithOne()
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata
        }
    }
}
