namespace App.Data.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Data.Core;
    using App.Data.Core.Entities;

    public partial class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("name=Models")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuSubItem> MenuSubItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Discounts)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("Discount_ApplyToCategories").MapLeftKey("CategoryId").MapRightKey("DiscountId"));

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.DiscountPercentage)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Discount>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.DiscountUsageHistories)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Discounts)
                .Map(m => m.ToTable("Discount_ApplyToProducts").MapLeftKey("DiscountId").MapRightKey("ProductId"));

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.MenuSubItems)
                .WithRequired(e => e.MenuItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderShipping)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderDiscount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.RefundedAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderSubTotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DiscountUsageHistories)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.LineTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Width)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Length)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Hight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
