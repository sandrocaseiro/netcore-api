using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Models.Domain;

namespace NetCoreAPI.Data.EF
{
    public class EFContext : DbContext
    {
        public DbSet<EGroup> Groups { get; set; }
        public DbSet<ERole> Roles { get; set; }
        public DbSet<EUserRole> UserRoles { get; set; }
        public DbSet<EUser> Users { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
            : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
