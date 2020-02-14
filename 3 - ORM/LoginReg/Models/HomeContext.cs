using Microsoft.EntityFrameworkCore;
using LoginReg.Models;

namespace LoginReg.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }
    }
}