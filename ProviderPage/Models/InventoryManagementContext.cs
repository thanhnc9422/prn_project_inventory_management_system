using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProviderPage.Models;

public partial class InventoryManagementContext : DbContext
{
    public InventoryManagementContext()
    {
    }

    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryDetail> DeliveryDetails { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database = InventoryManagement; uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Customers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Customer_Staff");
        });

        modelBuilder.Entity<DeliveryDetail>(entity =>
        {
            entity.HasKey(e => e.DeliveryDetailId).HasName("PK__Delivery__EFD2C2877454CF6A");

            entity.ToTable("DeliveryDetail");

            entity.Property(e => e.DeliveryDetailId).HasColumnName("DeliveryDetailID");
            entity.Property(e => e.ActualDate).HasColumnType("date");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");
            entity.Property(e => e.ExpectedDate).HasColumnType("date");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.DeliveryDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_DeliveryDetail_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.DeliveryDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_DeliveryDetail_Product");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Inventory_Product");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_Inventory_Warehouse");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C650F636B");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.ActualDate).HasColumnType("date");
            entity.Property(e => e.ExpectedDate).HasColumnType("date");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.TotalPayment).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_Product");

            entity.HasOne(d => d.Provider).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK_OrderDetail_Provider");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_OrderDetail_Warehouse");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED2BF5F653");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.OriginPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackedDepth).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackedHeight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackedWidth).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

            entity.HasOne(d => d.Provider).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK_Product_Provider");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__B54C689DF057D38C");

            entity.ToTable("Provider");

            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProviderAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProviderName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Staff_Role");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.Height).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Length).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Location)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Width).HasColumnType("decimal(10, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
