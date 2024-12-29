
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data.Models;

namespace PlaneTicketSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public required DbSet<PlaneTicketSystem.Data.Models.Booking> Bookings { get; set; }
        public required DbSet<PlaneTicketSystem.Data.Models.Admin> Admins { get; set; }
        public required DbSet<PlaneTicketSystem.Data.Models.User> Users { get; set; }
        public required DbSet<PlaneTicketSystem.Data.Models.Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaneTicketSystem.Data.Models.Booking>()
                .Property(b => b.Price)  
                .HasPrecision(10, 2);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.BasePrice)
                .HasPrecision(10, 2);
        }
    }
}