using Microsoft.EntityFrameworkCore;

namespace EFCoreBulkInsert.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Client>? Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name).HasMaxLength(200).IsRequired();

                entity.Property(c => c.Email).HasMaxLength(150).IsRequired();

                entity.Property(c => c.Phone).HasMaxLength(50).IsRequired();

            });
        }
    }
}
