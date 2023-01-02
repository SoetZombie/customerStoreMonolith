// Define the Car class

using System.ComponentModel.DataAnnotations.Schema;

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

    [NotMapped] public string CarAge { get; set; }
}