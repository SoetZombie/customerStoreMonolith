var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// using CustomerStoreMonolith;
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         var builder = WebApplication.CreateBuilder(args);
//         var app = builder.Build();
//
//         app.MapGet("/", () => "Hello World!");
//
//         app.Run();
//         // Create a new instance of the database context
//         var context = new CustomerController.CustomerCarContext();
//
//         // Create a new customer
//         var customer = new CustomerController.Customer
//         {
//             Name = "John Doe",
//             Email = "johndoe@gmail.com"
//         };
//
//         // Add the customer to the database
//         context.Customers.Add(customer);
//
//         // Create a new car for the customer
//         var car = new CustomerController.Car
//         {
//             Make = "Ford",
//             Model = "Mustang",
//             Year = 2020,
//             Customer = customer,
//             FirstRegistration = DateTime.UtcNow
//         };
//
//         // Add the car to the database
//         context.Cars.Add(car);
//
//         // Save the changes to the database
//         context.SaveChanges();
//
//         // Query the database to get the customer's cars
//         var cars = context.Cars
//             .Where(c => c.CustomerId == customer.Id)
//             .ToList();
//
//         // Print the details of the customer's cars
//         // Console.WriteLine("{0}'s cars:", customer.Name);
//         // foreach (var c in cars)
//         // {
//         //     Console.WriteLine("{0} {1} ({2}) age:{3}", c.Make, c.Model, c.Year, c.CarAge);
//         // }
//     }
// }
