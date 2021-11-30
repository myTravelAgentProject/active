using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class MyTravelAgentContext : DbContext
    {
        public MyTravelAgentContext()
        {
        }

        public MyTravelAgentContext(DbContextOptions<MyTravelAgentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerChild> CustomerChildren { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LIH23BI\\SQLEXPRESS;Database=MyTravelAgent;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Comments)
                    .HasColumnType("text")
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.HighFloor).HasColumnName("HIGH_FLOOR");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MultipleRooms).HasColumnName("MULTIPLE_ROOMS");

                entity.Property(e => e.NumOfAdults).HasColumnName("NUM_OF_ADULTS");

                entity.Property(e => e.NumOfKids).HasColumnName("NUM_OF_KIDS");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PHONE_NUMBER")
                    .IsFixedLength(true);

                entity.Property(e => e.Porch).HasColumnName("PORCH");

                entity.Property(e => e.SeprateBeds).HasColumnName("SEPRATE_BEDS");
            });

            modelBuilder.Entity<CustomerChild>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerChildren)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerChildren_Customers");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accessibility)
                    .HasMaxLength(255)
                    .HasColumnName("ACCESSIBILITY");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("CITY");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Kosher)
                    .HasMaxLength(255)
                    .HasColumnName("KOSHER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("NAME");

                entity.Property(e => e.Parking)
                    .HasMaxLength(255)
                    .HasColumnName("PARKING");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PtoductUrl)
                    .HasMaxLength(255)
                    .HasColumnName("PTODUCT_URL");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("REGION");

                entity.Property(e => e.SwimmingPool)
                    .HasMaxLength(255)
                    .HasColumnName("SWIMMING_POOL");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");

                entity.Property(e => e.WiFi).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BOOKING_DATE");

                entity.Property(e => e.BookingId).HasColumnName("BOOKING_ID");

                entity.Property(e => e.Change).HasColumnName("CHANGE");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("CHECK_IN_DATE");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("date")
                    .HasColumnName("CHECK_OUT_DATE");

                entity.Property(e => e.Comments)
                    .HasColumnType("text")
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CostPrice).HasColumnName("COST_PRICE");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.EarlyCheckIn).HasColumnName("EARLY_CHECK_IN");

                entity.Property(e => e.FloorHeight).HasColumnName("FLOOR_HEIGHT");

                entity.Property(e => e.HotelId).HasColumnName("HOTEL_ID");

                entity.Property(e => e.LateCheckOut).HasColumnName("LATE_CHECK_OUT");

                entity.Property(e => e.MultipleRooms).HasColumnName("MULTIPLE_ROOMS");

                entity.Property(e => e.NewPrice).HasColumnName("NEW_PRICE");

                entity.Property(e => e.NumOfAdults).HasColumnName("NUM_OF_ADULTS");

                entity.Property(e => e.NumOfKids).HasColumnName("NUM_OF_KIDS");

                entity.Property(e => e.SeprateBeds).HasColumnName("SEPRATE_BEDS");

                entity.Property(e => e.StatusCode).HasColumnName("STATUS_CODE");

                entity.Property(e => e.TotalPrice).HasColumnName("TOTAL_PRICE");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Hotels22");

                entity.HasOne(d => d.StatusCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Status");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .HasColumnName("AREA");

                entity.Property(e => e.ArriveDate)
                    .HasColumnType("date")
                    .HasColumnName("ARRIVE_DATE");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.LeavingDate)
                    .HasColumnType("date")
                    .HasColumnName("LEAVING_DATE");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Customers");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DESCRIPTION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
