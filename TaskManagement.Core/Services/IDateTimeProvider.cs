namespace TaskManagement.Core.Services;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
    DateTimeOffset UtcNow { get; }
}