namespace CommonService.Services;

public class CommonService: ICommonService
{
    public Task<int> CalculateAge(DateTime start, DateTime end)
    {
        return Task.FromResult((end - start).Days);
    }
}