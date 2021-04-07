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
    }
}