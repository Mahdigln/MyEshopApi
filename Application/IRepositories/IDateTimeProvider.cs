namespace Application.IRepositories
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
