using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        protected new readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
            => _context = context;
    }
}
