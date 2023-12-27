using Application.Features.Address.Commands.AddAddress;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Address;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AddressController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AddAddress/{customerId}")]
        public async Task<IActionResult> AddAddress(int customerId, [FromForm] AddAddressDto addAddress,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map(addAddress, new AddAddressCommandRequest());
            command.CustomerId = customerId;
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
            if (isSuccessful)
                return Ok();

            return BadRequest();


        }

    }
}
