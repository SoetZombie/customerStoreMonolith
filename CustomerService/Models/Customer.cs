public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // Navigation property for the customer's cars
    public virtual ICollection<Car> Cars { get; set; }
}