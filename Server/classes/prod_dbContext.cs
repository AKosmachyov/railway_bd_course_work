using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server
{
    public partial class prod_dbContext : DbContext
    {
        public virtual DbSet<Arrivaltime> Arrivaltime { get; set; }
        public virtual DbSet<Carriage> Carriage { get; set; }
        public virtual DbSet<Carriagetype> Carriagetype { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Locomotive> Locomotive { get; set; }
        public virtual DbSet<Point> Point { get; set; }
        public virtual DbSet<Prefix> Prefix { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Traincompositioncarriage> Traincompositioncarriage { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Host=localhost;Port=3306;Database=prod_db;Username=root;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arrivaltime>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TripId, e.PointId });

                entity.ToTable("arrivaltime");

                entity.HasIndex(e => e.PointId)
                    .HasName("fk_ArrivalTime_Point1_idx");

                entity.HasIndex(e => e.TripId)
                    .HasName("fk_ArrivalTime_ Trip1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TripId)
                    .HasColumnName("trip_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PointId)
                    .HasColumnName("point_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArriveTime)
                    .HasColumnName("arriveTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Carriage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CarriageTypeId });

                entity.ToTable("carriage");

                entity.HasIndex(e => e.CarriageTypeId)
                    .HasName("fk_Carriage_CarriageType1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarriageTypeId)
                    .HasColumnName("carriageType_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Seats)
                    .HasColumnName("seats")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CarriageType)
                    .WithMany(p => p.Carriage)
                    .HasForeignKey(d => d.CarriageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Carriage_CarriageType1");
            });

            modelBuilder.Entity<Carriagetype>(entity =>
            {
                entity.ToTable("carriagetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Pricefactor).HasColumnName("pricefactor");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RegionId });

                entity.ToTable("city");

                entity.HasIndex(e => e.RegionId)
                    .HasName("fk_City_Region1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Locomotive>(entity =>
            {
                entity.ToTable("locomotive");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PricePerKilometer).HasColumnName("price_per_kilometer");
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RouteId, e.StationId });

                entity.ToTable("point");

                entity.HasIndex(e => e.RouteId)
                    .HasName("fk_Point_Route1_idx");

                entity.HasIndex(e => e.StationId)
                    .HasName("fk_Point_Station1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StayTime)
                    .HasColumnName("stayTime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TripDistance)
                    .HasColumnName("tripDistance")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Point)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Point_Route1");
            });

            modelBuilder.Entity<Prefix>(entity =>
            {
                entity.ToTable("prefix");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CountryId });

                entity.ToTable("region");

                entity.HasIndex(e => e.CountryId)
                    .HasName("fk_Region_Country1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CountryId)
                    .HasColumnName("Country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Region_Country1");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("route");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PrefixId, e.CityId });

                entity.ToTable("station");

                entity.HasIndex(e => e.CityId)
                    .HasName("fk_Station_City1_idx");

                entity.HasIndex(e => e.PrefixId)
                    .HasName("fk_Station_Prefix1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PrefixId)
                    .HasColumnName("prefix_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Prefix)
                    .WithMany(p => p.Station)
                    .HasForeignKey(d => d.PrefixId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Station_Prefix1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Depart, e.Arrive, e.UserId });

                entity.ToTable("ticket");

                entity.HasIndex(e => e.Arrive)
                    .HasName("fk_Ticket_ArrivalTime4_idx");

                entity.HasIndex(e => e.Depart)
                    .HasName("fk_Ticket_ArrivalTime3_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Ticket_User3_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Depart)
                    .HasColumnName("depart")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Arrive)
                    .HasColumnName("arrive")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CarriageNumber)
                    .HasColumnName("carriage_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_User3");
            });

            modelBuilder.Entity<Traincompositioncarriage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CarriageId, e.TripId });

                entity.ToTable("traincompositioncarriage");

                entity.HasIndex(e => e.CarriageId)
                    .HasName("fk_Carriage_trip_Carriage1_idx");

                entity.HasIndex(e => e.TripId)
                    .HasName("fk_TrainCompositionCarriage_Trip1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarriageId)
                    .HasColumnName("carriage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TripId)
                    .HasColumnName("trip_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookSeats)
                    .HasColumnName("book_seats")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LocomotiveId });

                entity.ToTable("trip");

                entity.HasIndex(e => e.LocomotiveId)
                    .HasName("fk_Trip_Locomotive1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LocomotiveId)
                    .HasColumnName("locomotive_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Locomotive)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.LocomotiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Trip_Locomotive1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(255);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middleName")
                    .HasMaxLength(255);

                entity.Property(e => e.PassportSerial)
                    .IsRequired()
                    .HasColumnName("passportSerial")
                    .HasMaxLength(10);
            });
        }
    }
}
