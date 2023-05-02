using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurant.Models
{
    public partial class restaurantContext : DbContext
    {
        

        public restaurantContext(DbContextOptions<restaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryDish> CategoryDishes { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuCategory> MenuCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=M5387465\\SQLEXPRESS;Database=restaurant;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryDish>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.DishId });

                entity.ToTable("Category_Dish");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___Categ__656C112C");

                entity.HasOne(d => d.Dish)
                    .WithMany()
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___DishI__66603565");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dish");

                entity.Property(e => e.DishId)
                    .ValueGeneratedNever()
                    .HasColumnName("DishID");

                entity.Property(e => e.DishDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DishImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nature)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.MenuId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuID");

                entity.Property(e => e.MenuDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MenuImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.CategoryId });

                entity.ToTable("Menu_Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Menu_Cate__Categ__5EBF139D");

                entity.HasOne(d => d.Menu)
                    .WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Menu_Cate__MenuI__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
