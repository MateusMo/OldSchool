using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolInfrastructure.Data.Fluent
{
    public class MindsetConfiguration : IEntityTypeConfiguration<MindsetDomain>
    {
        public void Configure(EntityTypeBuilder<MindsetDomain> builder)
        {
            builder.ToTable("Mindset"); // Nome da tabela
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); // Geração automática de ID

            builder.Property(c => c.UserId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(c => c.Likes)
                .HasColumnType("INT")
                .IsRequired(false);

            builder.Property(c => c.Content)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
               .IsRequired()
               .HasColumnType("DateTime");
            builder.Property(u => u.UpdatedAt)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.HasMany(p => p.Posts)
                   .WithOne()
                   .HasForeignKey(c => c.MindsetId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
