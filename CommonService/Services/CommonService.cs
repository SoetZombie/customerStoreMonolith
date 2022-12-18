namespace CommonService.Services;

public class CommonService: ICommonService
{
    public Task<TimeSpan> CalculateAge(DateTime start, DateTime end)
    {
        return Task.FromResult(start - end);
    }
}