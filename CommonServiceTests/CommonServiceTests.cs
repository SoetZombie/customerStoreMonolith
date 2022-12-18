namespace CommonServiceTests;

public class Tests
{
    public CommonService.Services.CommonService _CommonService;
    [SetUp]
    public void Setup()
    {
        _CommonService = new CommonService.Services.CommonService(); 
    }

    [Test]
    public async Task Calculate_Days_Correctly()
    {
        //Arrange 
        var start = new DateTime(2018, 10, 10);
        var end = new DateTime(2020, 10, 10);

        var result = await _CommonService.CalculateAge(start, end);
        Assert.That(result, Is.EqualTo(731));
    }
    
    [Test]
    public async Task Calculate_Days_Correctly_Including_Short_Years()
    {
        //Arrange 
        var start = new DateTime(2010, 10, 10);
        var end = new DateTime(2020, 10, 10);

        var result = await _CommonService.CalculateAge(start, end);
        Assert.That(result, Is.EqualTo(3653));
    }
}