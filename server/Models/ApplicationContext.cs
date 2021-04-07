using Microsoft.EntityFrameworkCore;
 
namespace Server.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            System.Console.WriteLine("Test");
            var created = Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Demo", Price = 200, Description = "descr"},
                new Product {Id = 2, Name = "Demo1", Price = 300, Description = "Long description"}
            );
            
        }
    }
}