using Application.Features.OrderItem.Commands.AddOrderItem;
using Application.Features.OrderItem.Commands.DeleteOrderItem;
using Application.Features.OrderItem.Queries.GetOrderItem;
using Application.Features.OrderItem.Queries.GetOrderItemById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.OrderItem;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> AddOrderItem([FromForm] AddOrderItemDto addOrderItem, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(addOrderItem, new AddOrderItemCommandRequest(addOrderItem.OrderId, addOrderItem.ProductId, addOrderItem.Quantity));
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
            if (isSuccessful)
                return Ok(command);

            return BadRequest();

        }
        [HttpGet("GetOrderItemById/{orderItemId}")]
        public async Task<IActionResult> GetOrderItem([FromRoute] int orderItemId, CancellationToken cancellationToken)
        {
            var orderItem = await _mediator.Send(new GetOrderItemByIdQueryRequest(orderItemId), cancellationToken);
            if (orderItem is not null)
            {
                return Ok(orderItem);
            }
            return NotFound();
        }

        [HttpGet("GetOrderItem")]
        public async Task<IActionResult> GetOrderItem(CancellationToken cancellationToken)
        {
            var orderItems = await _mediator.Send(new GetOrderItemQueryRequest(), cancellationToken);
            if (orderItems != null)
            {
                return Ok(orderItems);
            }
            return NotFound();
        }

        [HttpDelete("DeleteOrderItem/{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId, CancellationToken cancellationToken)
        {
            bool isSuccessful = await _mediator.Send(new DeleteOrderItemCommandRequest(orderItemId), cancellationToken);
            if (isSuccessful)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
