using Application.Features.Category.Commands.AddCategory;
using Application.Features.Payment.Commands.AddPayment;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Category;
using WebApi.DTOs.Payment;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromForm] AddPaymentDto addPaymentDto, CancellationToken cancellationToken)
                   {
            // var command =_mapper.Map(model, new AddCategoryCommandRequest(model.Name));
             var command = _mapper.Map(addPaymentDto, new AddPaymentCommandRequest());
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
            if (isSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
