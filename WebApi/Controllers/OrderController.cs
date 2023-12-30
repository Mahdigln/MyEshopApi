using Application.Features.Order.Commands.AddOrder;
using Application.Features.Order.Queries.GetOrder;
using Application.Features.Order.Queries.GetOrderById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Order;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(/*int customerId,*/ [FromForm] AddOrderDto addOrder, CancellationToken cancellationToken)
        {
            // string CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = _mapper.Map(addOrder, new AddOrderCommandRequest(addOrder.CustomerId, addOrder.ProductId));
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
            if (isSuccessful)
                return Ok(command);

            return BadRequest();

        }

        [HttpGet("GetOrderById/{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderByIdQueryRequest(orderId), cancellationToken);
            if (order is not null)
            {
                return Ok(order);
            }
            return NotFound();
        }

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder(CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderQueryRequest(), cancellationToken);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }
    }
}
