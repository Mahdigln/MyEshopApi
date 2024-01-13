using Domain.Models;

namespace Application.IRepositories
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Customer customer);
    }
}
