using Application.IRepositories;
using Application.PipelineBehaviors.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Payment.Commands.AddPayment;

public class AddPaymentCommandRequest: IRequest<bool>, IInventory
{
    public List<int> ProductIds { get; set; }
    public int OrderId { get; set; }
}


public class AddPaymentCommandRequestHandler : IRequestHandler<AddPaymentCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentRepository _paymentRepository;

    public AddPaymentCommandRequestHandler(IMapper mapper, IOrderRepository orderRepository, IPaymentRepository paymentRepository)
    {
                   _mapper = mapper;
        _orderRepository = orderRepository;
        _paymentRepository = paymentRepository;
    }
    public async Task<bool> Handle(AddPaymentCommandRequest request, CancellationToken cancellationToken)
    {
         var order =await  _orderRepository.Get(request.OrderId, cancellationToken);
        if (order is not null)
        {
            order.IsFinally = true;
            var payment = _mapper.Map<Domain.Models.Payment>(request);
            payment.PaymentTime = DateTime.Now;
            payment.IsSuccess = true;
            payment.Amount = order.Sum;
            await _paymentRepository.Add(payment, cancellationToken);
           await _paymentRepository.Save();
            return true;
        }
        else
        {
            return false;
        }

       
    }
}