using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class HomeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HomeContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Rsvp> Rsvps { get; set; }


    }
}