using Microsoft.EntityFrameworkCore;

namespace CrudBasicoNETCoreMVC.Models
{
    public class CrudDbContext : DbContext
    {
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Modelo> Modelo { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=crudnetcoremvc.db");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Caminhao>()
                .HasOne(p => p.Modelo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
