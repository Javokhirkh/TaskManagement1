namespace TaskManagement.Core.Services;

public class DateTimeProvider:IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
    
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}