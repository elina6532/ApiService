using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Models;

public partial class SkyMarketContext : DbContext
{
    public SkyMarketContext()
    {
    }

    public SkyMarketContext(DbContextOptions<SkyMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Pickuppoint> Pickuppoints { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productphoto> Productphotos { get; set; }

    public virtual DbSet<Productsize> Productsizes { get; set; }

    public virtual DbSet<Returnaction> Returnactions { get; set; }

    public virtual DbSet<Returnrequest> Returnrequests { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;username=postgres;database=SkyMarket;password=Elina2030");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("cart_pkey");

            entity.ToTable("cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.AddDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("add_date");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("cart_article_fkey");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("cart_id_client_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.IdDiscount).HasName("discount_pkey");

            entity.ToTable("discount");

            entity.Property(e => e.IdDiscount).HasColumnName("id_discount");
            entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(100)
                .HasColumnName("discount_type");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            entity.Property(e => e.PassportSerialNumber)
                .HasMaxLength(20)
                .HasColumnName("passport_serial_number");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("employees_id_position_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("employees_id_status_fkey");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("manufacturer_pkey");

            entity.ToTable("manufacturer");

            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.IdPickupPoint).HasColumnName("id_pickup_point");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.ReturnStatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("return_status");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalCost).HasColumnName("total_cost");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("orders_id_client_fkey");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("orders_id_employee_fkey");

            entity.HasOne(d => d.IdPickupPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPickupPoint)
                .HasConstraintName("orders_id_pickup_point_fkey");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.IdDetail).HasName("orderdetail_pkey");

            entity.ToTable("orderdetail");

            entity.Property(e => e.IdDetail).HasColumnName("id_detail");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReturnStatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("return_status");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("orderdetail_article_fkey");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("orderdetail_id_order_fkey");
        });

        modelBuilder.Entity<Pickuppoint>(entity =>
        {
            entity.HasKey(e => e.IdPickupPoint).HasName("pickuppoints_pkey");

            entity.ToTable("pickuppoints");

            entity.Property(e => e.IdPickupPoint).HasColumnName("id_pickup_point");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.IdPosition).HasColumnName("id_position");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdDiscount).HasColumnName("id_discount");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("product_id_category_fkey");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("product_id_discount_fkey");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturer)
                .HasConstraintName("product_id_manufacturer_fkey");
        });

        modelBuilder.Entity<Productphoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("productphoto_pkey");

            entity.ToTable("productphoto");

            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Productphotos)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("productphoto_article_fkey");
        });

        modelBuilder.Entity<Productsize>(entity =>
        {
            entity.HasKey(e => e.IdProductSize).HasName("productsize_pkey");

            entity.ToTable("productsize");

            entity.Property(e => e.IdProductSize).HasColumnName("id_product_size");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.IdSize).HasColumnName("id_size");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Productsizes)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("productsize_article_fkey");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.Productsizes)
                .HasForeignKey(d => d.IdSize)
                .HasConstraintName("productsize_id_size_fkey");
        });

        modelBuilder.Entity<Returnaction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("returnactions_pkey");

            entity.ToTable("returnactions");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionDate).HasColumnName("action_date");
            entity.Property(e => e.ActionDescription).HasColumnName("action_description");
            entity.Property(e => e.ActionStatus)
                .HasMaxLength(30)
                .HasColumnName("action_status");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Returnactions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("returnactions_employee_id_fkey");

            entity.HasOne(d => d.Request).WithMany(p => p.Returnactions)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("returnactions_request_id_fkey");
        });

        modelBuilder.Entity<Returnrequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("returnrequests_pkey");

            entity.ToTable("returnrequests");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Ожидает обработки'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Returnrequests)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("returnrequests_article_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Returnrequests)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("returnrequests_order_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("reviews_pkey");

            entity.ToTable("reviews");

            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .HasColumnName("client_name");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate).HasColumnName("review_date");

            entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Article)
                .HasConstraintName("reviews_article_fkey");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.IdSize).HasName("size_pkey");

            entity.ToTable("size");

            entity.Property(e => e.IdSize).HasColumnName("id_size");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
