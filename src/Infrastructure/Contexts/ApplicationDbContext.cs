using dummyApi.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dummyApi.src.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Market> Markets { get; set; }
        public DbSet<Location> Locations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.State).IsRequired();
                entity.Property(e => e.Country).IsRequired();
                entity.Property(e => e.ZipCode).IsRequired();
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.Location);
            });
        }
    }
}
