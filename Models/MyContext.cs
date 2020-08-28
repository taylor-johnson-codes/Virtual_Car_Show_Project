using Microsoft.EntityFrameworkCore;

namespace Virtual_Car_Show_Project.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users {get;set;}

        public DbSet<Car> Cars {get;set;}

        public DbSet<CarShow> CarShows {get;set;}

        public DbSet<RegisteredCars> RegisteredCars {get;set;}
    }
}
