using Microsoft.EntityFrameworkCore;
using OldSchoolDomain.Data.Configurations;
using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolInfrastructure.Data
{
    public class OldSchoolContext : DbContext
    {
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<PostDomain> Posts { get; set; }
        public DbSet<CommentDomain> Comments { get; set; }

        public OldSchoolContext(DbContextOptions<OldSchoolContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
