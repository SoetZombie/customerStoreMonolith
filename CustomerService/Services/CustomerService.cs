using Microsoft.EntityFrameworkCore;

namespace CustomerService.Services;

public class CustomerService: ICustomerService 
{
    public Customer GetData(int customerId)
    {
        var context = new CustomerCarContext();
        var data = context.Customers
            .Include(x => x.Cars)
            .FirstOrDefault(x => x.Id == customerId);
        
        return data;
    }
}