using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class Northwind2Context : DbContext
    {
        //public Northwind2Context()
        //{
        //}

        public Northwind2Context(DbContextOptions<Northwind2Context> options)
      : base(options)
        {
        }

        public DbSet<TOPMenu> TOPMenu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Database=Northwind2;User ID=mvc2;Password=P@ssw0rd;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TOPMenu>(entity =>
            {
                entity.Property(e => e.TOPMenuId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Icon).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Url).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Orders).IsRequired();
            });
        }

    }
}
