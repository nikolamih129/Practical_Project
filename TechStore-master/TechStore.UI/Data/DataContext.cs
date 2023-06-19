using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechStore.UI.Models;

namespace TechStore.UI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("prddetails");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.Make)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                /*
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                */

                entity.Property(e => e.Characteristics)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
