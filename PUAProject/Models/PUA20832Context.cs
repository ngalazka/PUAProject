using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PUAProject.Models
{
    public partial class PUA20832Context : DbContext
    {
       
        public string DBPath { get; set; }

        public PUA20832Context()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DBPath = Path.Join(path, "PUA-20832");
        }

        public PUA20832Context(DbContextOptions<PUA20832Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ShipAddress> ShipAddresses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=PUA-20832;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories", "Products");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LastModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Orders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatus).HasMaxLength(100);

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.RequiredDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShippedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Orders");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems", "Orders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Users");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "Products");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageUrl).HasMaxLength(300);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LastModifiedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductTitle).HasMaxLength(250);

                entity.Property(e => e.PublicationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<ShipAddress>(entity =>
            {
                entity.ToTable("ShipAddresses", "Addresses");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Number).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Street).HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LastModifiedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(250);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_ShipAddresses");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        public void SeedInitialData()
        {
            if (Products.Any())
            {
                Products.RemoveRange(Products);
                SaveChanges();
            }
            if (Categories.Any())
            {
                Categories.RemoveRange(Categories);
                SaveChanges();
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
