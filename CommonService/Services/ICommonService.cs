namespace CommonService.Services;

public interface ICommonService
{
    Task<TimeSpan> CalculateAge(DateTime start, DateTime end);
} 