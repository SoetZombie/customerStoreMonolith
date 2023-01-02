using Microsoft.EntityFrameworkCore;

namespace CustomerService;
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