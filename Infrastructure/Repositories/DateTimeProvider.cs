using Application.IRepositories;

namespace Infrastructure.Repositories
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
