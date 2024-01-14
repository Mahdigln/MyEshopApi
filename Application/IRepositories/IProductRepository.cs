using Application.Response.Product;
using Domain.Models;

namespace Application.IRepositories;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllByQueryFilter(ProductQueryParametersResponse queryParameters, CancellationToken cancellationToken);
    Task<bool> IsProductNameExist(string productName, CancellationToken cancellationToken);
    Task<int> GetProductInventoryCount(int productId, CancellationToken cancellationToken);
}

