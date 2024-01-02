using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class PaymentRepository:GenericRepository<Payment>,IPaymentRepository
{
    protected new readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context) : base(context)
        => _context = context;
}