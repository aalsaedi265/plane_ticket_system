
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

        public DbSet<PlaneTicketSystem.Data.Models.Booking> Bookings { get; set; }
        public DbSet<PlaneTicketSystem.Data.Models.Admin> Admins { get; set; }
        public DbSet<PlaneTicketSystem.Data.Models.User> Users { get; set; }
        public DbSet<PlaneTicketSystem.Data.Models.Schedule> Schedules { get; set; }
    }
}