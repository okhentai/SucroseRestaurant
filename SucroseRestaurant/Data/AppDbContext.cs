using Admin.Models.Bookings;
using Admin.Models.Categories;
using Admin.Models.Foods;
using Admin.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Admin.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Make add Migration work
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.Value });

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            ConfigurationManager config = new ConfigurationManager();
            var connectionString = config.GetConnectionString("Localdb");
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=FoodDB;" +
                "Trusted_Connection=True;MultipleActiveResultSets=true"
                );
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
