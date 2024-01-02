using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        protected new readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
            => _context = context;

        public async Task<IEnumerable<Product>> GetAllByQueryFilter(ProductQueryParametersResponse queryParameters, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = _context.Products;
            if (queryParameters.MinPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price <= queryParameters.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(
                    p => p.Name.ToLower().Contains(
                        queryParameters.Name.ToLower()));
            }

            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);
            return await products.ToListAsync(cancellationToken: cancellationToken);

        }

        public async Task<bool> IsProductNameExist(string productName,CancellationToken cancellationToken)
        {
           return await _context.Products.AnyAsync(a => a.Name == productName, cancellationToken: cancellationToken);
        }
    }
}
