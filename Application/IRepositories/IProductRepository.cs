using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response.Product;

namespace Application.IRepositories;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllByQueryFilter(ProductQueryParametersResponse queryParameters, CancellationToken cancellationToken);
    Task<bool> IsProductNameExist(string productName,CancellationToken cancellationToken);

}

