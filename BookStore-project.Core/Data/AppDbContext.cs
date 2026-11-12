using System;
using System.Collections.Generic;
//using BookStore.API.Models;
using BookStore_project.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStore.API.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<VwSalesByCategory> VwSalesByCategories { get; set; }

    public virtual DbSet<VwTopRatedBook> VwTopRatedBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=localhost:1521/xe;User Id=BOOKSTORE_USER;Password=BookStore123#;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BOOKSTORE_USER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("SYS_C008336");

            entity.ToTable("ADMINS");

            entity.HasIndex(e => e.Username, "SYS_C008337").IsUnique();

            entity.Property(e => e.AdminId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_HASH");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("SYS_C008344");

            entity.ToTable("AUTHORS");

            entity.Property(e => e.AuthorId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("AUTHOR_ID");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("AUTHOR_NAME");
            entity.Property(e => e.Bio)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("BIO");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("SYS_C008340");

            entity.ToTable("CATEGORIES");

            entity.HasIndex(e => e.CategoryName, "SYS_C008341").IsUnique();

            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("SYS_C008373");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DELIVERY_ADDRESS");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("SYSDATE\n")
                .HasColumnType("DATE")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("'Pending' ")
                .HasColumnName("ORDER_STATUS");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("'Cash on Delivery'")
                .HasColumnName("PAYMENT_METHOD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL_AMOUNT");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("SYS_C008380");

            entity.ToTable("ORDER_ITEMS");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ORDER_ITEM_ID");
            entity.Property(e => e.OrderId)
                .HasColumnType("NUMBER")
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductId)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("UNIT_PRICE");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_ITEM_ORDER");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ITEM_PRODUCT");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("SYS_C008357");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.AuthorId)
                .HasColumnType("NUMBER")
                .HasColumnName("AUTHOR_ID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CoverImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("COVER_IMAGE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsBestSeller)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_BEST_SELLER");
            entity.Property(e => e.IsFeatured)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_FEATURED");
            entity.Property(e => e.IsNewArrival)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_NEW_ARRIVAL");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("'BOOK' ")
                .HasColumnName("PRODUCT_TYPE");
            entity.Property(e => e.PublicationYear)
                .HasPrecision(4)
                .HasColumnName("PUBLICATION_YEAR");
            entity.Property(e => e.PublisherId)
                .HasColumnType("NUMBER")
                .HasColumnName("PUBLISHER_ID");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER")
                .HasColumnName("STOCK_QUANTITY");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Author).WithMany(p => p.Products)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_PROD_AUTHOR");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_PROD_CATEGORY");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Products)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_PROD_PUBLISHER");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("SYS_C008347");

            entity.ToTable("PUBLISHERS");

            entity.Property(e => e.PublisherId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PUBLISHER_ID");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTACT_EMAIL");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PUBLISHER_NAME");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("SYS_C008366");

            entity.ToTable("REVIEWS");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("REVIEW_ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.ProductId)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Rating)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("RATING");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("REVIEW_DATE");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_REVIEW_PRODUCT");
        });

        modelBuilder.Entity<VwSalesByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_SALES_BY_CATEGORY");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
            entity.Property(e => e.TotalSales)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_SALES");
        });

        modelBuilder.Entity<VwTopRatedBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_TOP_RATED_BOOKS");

            entity.Property(e => e.AverageRating)
                .HasColumnType("NUMBER")
                .HasColumnName("AVERAGE_RATING");
            entity.Property(e => e.ProductId)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITLE");
            entity.Property(e => e.TotalReviews)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_REVIEWS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
