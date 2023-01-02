using System.Text;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Customer?> GetCustomerData([FromRoute]int id)
    {
        var data = _customerService.GetData(id);

        foreach (var car in data?.Cars)
        {
            var client = new HttpClient();
            var request = JsonConvert.SerializeObject(new { Start = new DateTime(car.Year, 1, 1), End = DateTime.Now });
            var content = new StringContent(request ?? "", Encoding.UTF8, "application/json");
            var url = "https://localhost:44397/common";
        
            var result = client.PostAsync(url, content).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            car.CarAge = response;
        }

        return data;
    }
}