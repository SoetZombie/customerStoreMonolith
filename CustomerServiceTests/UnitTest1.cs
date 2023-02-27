using CustomerService = CustomerService.Services.CustomerService;

namespace CustomerServiceTests;

public class Tests
{
    public global::CustomerService.Services.CustomerService _CustomerService;

    [SetUp]
    public void Setup()
    {
        _CustomerService = new global::CustomerService.Services.CustomerService();
    }

    [Test]
    public void Get_Customer_Returns_Correct_Data()
    {
        var result = _CustomerService.GetData(1);
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void Get_Customer_Returns_Null_When_Customer_Does_Not_Exist()
    {
        var result = _CustomerService.GetData(100);
        Assert.IsNull(result);
    }
}