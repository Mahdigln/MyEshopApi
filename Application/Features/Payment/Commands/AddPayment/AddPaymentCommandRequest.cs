using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Payment.Commands.AddPayment;

//public class AddPaymentCommandRequest:IRequest<bool>
//{
//    public int PayId { get; set; }
//    public decimal Amount { get; set; }
//    public bool IsSuccess { get; set; }
//    public DateTime PaymentTime { get; set; }
//    public int OrderId { get; set; }
//}

//public class AddPaymentCommandRequestHandler : IRequestHandler<AddPaymentCommandRequest, bool>
//{
//    private readonly IMapper _mapper;
//    private readonly IOrderRepository _orderRepository;
//    private readonly IPaymentRepository _paymentRepository;

//    public AddPaymentCommandRequestHandler(IMapper mapper, IOrderRepository orderRepository, IPaymentRepository paymentRepository)
//    {
//        _mapper = mapper;
//        _orderRepository = orderRepository;
//        _paymentRepository = paymentRepository;
//    }
//    public Task<bool> Handle(AddPaymentCommandRequest request, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }
//}