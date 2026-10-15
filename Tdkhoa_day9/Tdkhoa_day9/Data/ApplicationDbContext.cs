using Microsoft.EntityFrameworkCore;
using Tdkhoa_day9.Models;

namespace Tdkhoa_day9.Data
{
    public class ApplicationDbContext : DbContext
    {
        // ... giữ nguyên phần còn lại
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Banner>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .Property(c => c.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Banner>()
                .Property(b => b.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Blog>()
                .Property(b => b.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Banner>()
                .Property(b => b.Prioty)
                .HasDefaultValue(0);

            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedDate)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            modelBuilder.Entity<Blog>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");
        }
    }
}