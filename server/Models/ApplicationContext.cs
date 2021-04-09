using Microsoft.EntityFrameworkCore;
 
namespace Server.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            var created = Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var firstCat = new Category {Id = 1, Name = "First"};
            var secondCat  = new Category {Id = 2, Name = "Second"};
            modelBuilder.Entity<Category>().HasData(
                firstCat,
                secondCat
            );

            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Demo", Price = 200, Description = "descr", CategoryId = 1},
                new Product {Id = 2, Name = "Demo1", Price = 300, Description = "Long description",CategoryId = 2}
            );
            
        }
    }
}