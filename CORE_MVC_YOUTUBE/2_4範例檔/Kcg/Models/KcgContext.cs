using Kcg.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Kcg.Models
{
    public class KcgContext : DbContext
    {
        public KcgContext(DbContextOptions<KcgContext> options) : base(options)
        {
        }

        public DbSet<TOPMenu> TOPMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TOPMenu>().HasData(
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "網站導覽", Url = "a1", Icon = "Icon1", Orders = 1 },
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "回首頁", Url = "a2", Icon = "Icon2", Orders = 2 },
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "English", Url = "a3", Icon = "Icon3", Orders = 3 },
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "雙語詞彙", Url = "a4", Icon = "Icon4", Orders = 4 },
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "市長信箱", Url = "a5", Icon = "Icon5", Orders = 5 },
                new TOPMenu { TOPMenuId = Guid.NewGuid(), Name = "洽公導覽", Url = "a6", Icon = "Icon6", Orders = 6 });

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
