using Microsoft.EntityFrameworkCore;

namespace Virtual_Car_Show_Project.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // public DbSet<User> Users { get; set; }
    }
}
