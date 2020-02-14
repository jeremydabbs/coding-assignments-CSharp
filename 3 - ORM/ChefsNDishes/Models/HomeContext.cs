using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class HomeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public HomeContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
    }
}