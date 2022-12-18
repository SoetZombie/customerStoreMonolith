using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerStoreMonolith;

[Route("customers")]
public class CustomerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property for the customer's cars
        public virtual ICollection<Car> Cars { get; set; }
    }

    // Define the Car class
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime FirstRegistration { get; set; }

        // Foreign key for the customer who owns the car
        public int CustomerId { get; set; }

        // Navigation property for the car's customer
        public virtual Customer Customer { get; set; }

        [NotMapped] public TimeSpan CarAge => DateTime.UtcNow - this.FirstRegistration;
    }

    
    // Define the database context
    public class CustomerCarContext : DbContext
    {
        public DbSet<CustomerController.Customer> Customers { get; set; }
        public DbSet<CustomerController.Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use a SQLite database for this example
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER2;Database=customercar;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }
    }
}