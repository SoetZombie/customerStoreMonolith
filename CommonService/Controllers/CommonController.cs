using CommonService.Messaging.Request;
using CommonService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommonService.Controllers;
[ApiController]
[Route("[controller]")]
public class CommonController : Controller
{
    private ICommonService _commonService;

    public CommonController(ICommonService commonService)
    {
        _commonService = commonService;
    }

    [HttpPost]
    public async Task<TimeSpan> CalculateAge([FromBody] CalculateAgeRequestModel model)
    {
        return await _commonService.CalculateAge(model.Start, model.End);
    }
}