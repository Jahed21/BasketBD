using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketBD.Models.Data
{
    public partial class BasketBDContext : DbContext
    {
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ItemPicture> ItemPicture { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<NewArrival> NewArrival { get; set; }
        public virtual DbSet<SlidePictures> SlidePictures { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BasketBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.CategoryName, e.SubCategory });

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.SubCategory).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<ItemPicture>(entity =>
            {
                entity.HasKey(e => new { e.SlNo, e.ItemCode });

                entity.Property(e => e.SlNo).HasMaxLength(100);

                entity.Property(e => e.ItemCode).HasMaxLength(100);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasMaxLength(100);

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.EexpireDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.PurchasePrice).HasColumnType("money");

                entity.Property(e => e.SalePrice).HasColumnType("money");

                entity.Property(e => e.SubCategory).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasMaxLength(100);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Items__BrandId__2D27B809");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Items__SupplierI__2C3393D0");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => new { d.Category, d.SubCategory })
                    .HasConstraintName("FK__Items__2E1BDC42");
            });

            modelBuilder.Entity<NewArrival>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<SlidePictures>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SubTitle).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
