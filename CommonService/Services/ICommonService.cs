namespace CommonService.Services;

public interface ICommonService
{
    Task<int> CalculateAge(DateTime start, DateTime end);
} 