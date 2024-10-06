using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldSchoolDomain.Domain;

namespace OldSchoolDomain.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentDomain>
    {
        public void Configure(EntityTypeBuilder<CommentDomain> builder)
        {
            builder.ToTable("Comments"); // Nome da tabela
            builder.HasKey(c => c.CommentId);
            builder.Property(c => c.CommentId)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); // Geração automática de ID

            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
        }
    }
}
