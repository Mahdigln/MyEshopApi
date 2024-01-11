using Application.Response.Product;
using Domain.Models;

namespace Application.IRepositories;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllByQueryFilter(ProductQueryParametersResponse queryParameters, CancellationToken cancellationToken);
    Task<bool> IsProductNameExist(string productName, CancellationToken cancellationToken);
    Task<List<Product>> GetProductIds(List<int> productIds, CancellationToken cancellationToken);
}

