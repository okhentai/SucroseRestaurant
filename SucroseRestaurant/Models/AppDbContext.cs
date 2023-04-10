using Admin.Models.Categories;
using Admin.Models.Foods;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Admin.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model

        }
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
