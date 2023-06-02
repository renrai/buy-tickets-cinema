using DataApplication.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataApplication.Database
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            
        }

        public DbSet<AuditoriumEntity> Auditoriums { get; set; }
        public DbSet<ShowtimeEntity> Showtimes { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<ReservationSeatsEntity> ReservationsSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditoriumEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasMany(entry => entry.Showtimes).WithOne().HasForeignKey(entity => entity.AuditoriumId);
            });

            modelBuilder.Entity<SeatEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasIndex(entry => new { entry.AuditoriumId, entry.Row, entry.SeatNumber }).IsUnique();
                build.HasOne(entry => entry.Auditorium).WithMany(entry => entry.Seats).HasForeignKey(entry => entry.AuditoriumId);

            });

            modelBuilder.Entity<ShowtimeEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasOne(entry => entry.Movie).WithMany(entry => entry.Showtimes);
                build.HasMany(entry => entry.Reservations).WithOne(entry => entry.Showtime).HasForeignKey(entry => entry.ShowtimeId);

            });

            modelBuilder.Entity<MovieEntity>(build =>
            {
                build.HasKey(u => u.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasIndex(i => i.ImdbId).IsUnique();
                build.HasMany(a => a.Showtimes).WithOne(a => a.Movie);
            });

            modelBuilder.Entity<TicketEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();

            });
            modelBuilder.Entity<ReservationEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasOne(entry => entry.Showtime).WithMany(entry => entry.Reservations);
                build.HasMany(entry => entry.Seats).WithOne(entry => entry.Reservation).HasForeignKey(y => y.ReservationId);

            });
            modelBuilder.Entity<ReservationSeatsEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasOne(entry => entry.Seat).WithMany().HasForeignKey(entry => entry.SeatId);
            });
        }
    }
}
