using Microsoft.EntityFrameworkCore;
using MyGarageDB.Entitys;
using MyGarageDB.Interfaces;

namespace MyGarageDB
{
    public partial class mygarageContext : DbContext, IDbContext
    {
        public mygarageContext()
        {
        }

        public mygarageContext(DbContextOptions<mygarageContext> options)
            : base(options)
        {
        }


        public virtual DbSet<GarageDB> Garages { get; set; } = null!;
        public virtual DbSet<TransportDB> Transports { get; set; } = null!;
        public virtual DbSet<TypeDB> Types { get; set; } = null!;
        public virtual DbSet<OvnerDB> Ovners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;database=mygarage66;uid=root;pwd=Tucha0425#", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");



            modelBuilder.Entity<GarageDB>(entity =>
            {
                entity.HasKey(c => c.Id)
                .HasName("PRIMARY");
                entity.ToTable("garage");
                entity.Property(e => e.Sity).HasMaxLength(20);
            });

            modelBuilder.Entity<TransportDB>(entity =>
            {
                entity.HasKey(e => e.IdTr)
                    .HasName("PRIMARY");

                entity.ToTable("transport");


                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .HasColumnName("brand");

                entity.Property(e => e.FuelQuntity).HasColumnName("fuelQuntity");

                entity.Property(e => e.FuelType)
                    .HasMaxLength(15)
                    .HasColumnName("fuelType");


                entity.Property(e => e.MaxSpeed).HasColumnName("maxSpeed");

                entity.Property(e => e.Namber)
                    .HasMaxLength(10)
                    .HasColumnName("namber");


            });

            modelBuilder.Entity<TypeDB>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");
                entity.ToTable("type");
                entity.Property(e => e.TypeTrans)
                    .HasMaxLength(10)
                    .HasColumnName("type");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
