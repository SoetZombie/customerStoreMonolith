using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomerStoreMonolith;

[ApiController]
[Route("[controller]")]
public class CustomersController : Controller
{
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Customer?> GetCustomerData([FromRoute]int id)
    {
        var context = new CustomerCarContext();
        var user = context.Customers.Include(x => x.Cars).FirstOrDefault(x => x.Id == id);
        
        return Json(user);
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use a SQLite database for this example
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER2;Database=customercar;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }
    }
}