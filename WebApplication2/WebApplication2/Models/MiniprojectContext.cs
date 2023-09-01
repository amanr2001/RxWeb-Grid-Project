using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class MiniprojectContext : DbContext
{
    public MiniprojectContext()
    {
    }

    public MiniprojectContext(DbContextOptions<MiniprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<MainPage> MainPages { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Objtype> Objtypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Outlet> Outlets { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Testd> Testds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC0382\\MSSQL2019;Database=miniproject;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Carid).HasName("PK__cars__1439FCAC26730B9E");

            entity.ToTable("cars");

            entity.Property(e => e.Carid).HasColumnName("carid");
            entity.Property(e => e.Carbrand)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("carbrand");
            entity.Property(e => e.Carmodel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("carmodel");
            entity.Property(e => e.Cartype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cartype");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Fueltype).HasColumnName("fueltype");
            entity.Property(e => e.Isapproved).HasColumnName("isapproved");
            entity.Property(e => e.Kmdriven).HasColumnName("kmdriven");
            entity.Property(e => e.Modelyear)
                .HasColumnType("date")
                .HasColumnName("modelyear");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Outletid).HasColumnName("outletid");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Seats).HasColumnName("seats");
            entity.Property(e => e.Sellerprice).HasColumnName("sellerprice");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.City).WithMany(p => p.Cars)
                .HasForeignKey(d => d.Cityid)
                .HasConstraintName("fkcity");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CarCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__cars__CreatedBy__4CA06362");

            entity.HasOne(d => d.FueltypeNavigation).WithMany(p => p.CarFueltypeNavigations)
                .HasForeignKey(d => d.Fueltype)
                .HasConstraintName("FK__cars__fueltype__45F365D3");

            entity.HasOne(d => d.IsapprovedNavigation).WithMany(p => p.CarIsapprovedNavigations)
                .HasForeignKey(d => d.Isapproved)
                .HasConstraintName("FK__cars__isapproved__4BAC3F29");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CarModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__cars__ModifiedBy__4D94879B");

            entity.HasOne(d => d.Outlet).WithMany(p => p.Cars)
                .HasForeignKey(d => d.Outletid)
                .HasConstraintName("FK__cars__outletid__4AB81AF0");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.CarOwnerNavigations)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK__cars__owner__46E78A0C");

            entity.HasOne(d => d.SeatsNavigation).WithMany(p => p.CarSeatsNavigations)
                .HasForeignKey(d => d.Seats)
                .HasConstraintName("FK__cars__seats__47DBAE45");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.CarStatusNavigations)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__cars__status__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.CarUsers)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__cars__userid__49C3F6B7");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Cityid).HasName("PK__city__B4BDBD26035C51C0");

            entity.ToTable("city");

            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Cityname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cityname");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Imageid).HasName("PK__images__336F9F7D081519EA");

            entity.ToTable("images");

            entity.Property(e => e.Imageid).HasColumnName("imageid");
            entity.Property(e => e.Backview)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("backview");
            entity.Property(e => e.Carid).HasColumnName("carid");
            entity.Property(e => e.Frontview)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("frontview");
            entity.Property(e => e.Leftside)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("leftside");
            entity.Property(e => e.Rightside)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rightside");

            entity.HasOne(d => d.Car).WithMany(p => p.Images)
                .HasForeignKey(d => d.Carid)
                .HasConstraintName("fkcar");
        });

        modelBuilder.Entity<MainPage>(entity =>
        {
            entity.HasKey(e => e.MainId).HasName("PK__MainPage__71F8F5CC66372B7D");

            entity.ToTable("MainPage");

            entity.Property(e => e.ImageText)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__Objects__530A638C70C53E1A");

            entity.Property(e => e.ObjId).HasColumnName("objId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Typeid).HasColumnName("typeid");

            entity.HasOne(d => d.Type).WithMany(p => p.Objects)
                .HasForeignKey(d => d.Typeid)
                .HasConstraintName("fkt");
        });

        modelBuilder.Entity<Objtype>(entity =>
        {
            entity.HasKey(e => e.Typeid).HasName("PK__objtypes__F0528D025BB8CAB7");

            entity.ToTable("objtypes");

            entity.Property(e => e.Typeid).HasColumnName("typeid");
            entity.Property(e => e.Name)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Parentid).HasColumnName("parentid");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.Parentid)
                .HasConstraintName("fkparent");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK__orders__080E3775B514E31C");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Orderstatus).HasColumnName("orderstatus");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__orders__CreatedB__5535A963");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OrderModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__orders__Modified__5629CD9C");

            entity.HasOne(d => d.OrderstatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Orderstatus)
                .HasConstraintName("FK__orders__ordersta__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.OrderUsers)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fkuser");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.Orderitem1).HasName("PK__orderite__4B4BCAB6E4F898E3");

            entity.ToTable("orderitems");

            entity.Property(e => e.Orderitem1).HasColumnName("orderitem");
            entity.Property(e => e.Carid).HasColumnName("carid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Car).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Carid)
                .HasConstraintName("fkcar1");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("fkorderitk");
        });

        modelBuilder.Entity<Outlet>(entity =>
        {
            entity.HasKey(e => e.Outletid).HasName("PK__outlet__91653A2D1167793D");

            entity.ToTable("outlet");

            entity.Property(e => e.Outletid).HasColumnName("outletid");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Outletlocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("outletlocation");

            entity.HasOne(d => d.City).WithMany(p => p.Outlets)
                .HasForeignKey(d => d.Cityid)
                .HasConstraintName("fkout");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("PK__payments__AF26EBEE041503BD");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Orderitem).HasColumnName("orderitem");
            entity.Property(e => e.Paymentamount).HasColumnName("paymentamount");
            entity.Property(e => e.Paymentdatetime)
                .HasColumnType("datetime")
                .HasColumnName("paymentdatetime");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("paymentstatus");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PaymentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fkcb");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PaymentModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("fbmb");

            entity.HasOne(d => d.OrderitemNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Orderitem)
                .HasConstraintName("fkoitem");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("PK__role__CD994BF260C6DC2E");

            entity.ToTable("role");

            entity.Property(e => e.Roleid)
                .ValueGeneratedNever()
                .HasColumnName("roleid");
            entity.Property(e => e.Role1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Testd>(entity =>
        {
            entity.HasKey(e => e.Testdid).HasName("PK__testd__F159626E67ED35C6");

            entity.ToTable("testd");

            entity.Property(e => e.Testdid).HasColumnName("testdid");
            entity.Property(e => e.Carid).HasColumnName("carid");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Car).WithMany(p => p.Testds)
                .HasForeignKey(d => d.Carid)
                .HasConstraintName("fkct");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TestdCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__testd__CreatedBy__628FA481");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TestdModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__testd__ModifiedB__6383C8BA");

            entity.HasOne(d => d.TestStatusNavigation).WithMany(p => p.Testds)
                .HasForeignKey(d => d.TestStatus)
                .HasConstraintName("FK__testd__TestStatu__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.TestdUsers)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fkut");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B25750B5512A");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.OtpExpDate).HasColumnType("datetime");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Useremail)
                .HasMaxLength(255)
                .HasColumnName("useremail");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.UserpassHashed)
                .IsUnicode(false)
                .HasColumnName("userpassHashed");
            entity.Property(e => e.UserpassSalt)
                .IsUnicode(false)
                .HasColumnName("userpassSalt");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("fkrole");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Wishlistid).HasName("PK__wishlist__46E7ADC8DE6B03AE");

            entity.ToTable("wishlist");

            entity.Property(e => e.Wishlistid).HasColumnName("wishlistid");
            entity.Property(e => e.Carid).HasColumnName("carid");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Wishliststatus).HasColumnName("wishliststatus");

            entity.HasOne(d => d.Car).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.Carid)
                .HasConstraintName("fkcarr");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fkuserr");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
