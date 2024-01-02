using Application.Features.Address.Commands.AddAddress;
using Application.Features.Address.Commands.DeleteAddress;
using Application.Features.Address.Commands.UpdateAddress;
using Application.Features.Address.Queries.GetAddress;
using Application.Features.Address.Queries.GetAddressByCustomerId;
using Application.Features.Address.Queries.GetAddressById;
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
                return Ok(command);

            return BadRequest();
        }

        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress(CancellationToken cancellationToken)
        {
            var address = await _mediator.Send(new GetAddressQueryRequest(), cancellationToken);
            if (address is not null)
                return Ok(address);

            return BadRequest();
        }
        [HttpGet("GetAddressByCustomer/{customerId}")]
        public async Task<IActionResult> GetAddressByCustomer(int customerId,CancellationToken cancellationToken)
        {
            var address = await _mediator.Send(new GetAddressByICustomerIdQueryRequest(customerId), cancellationToken);
            if (address is not null)
                return Ok(address);

            return BadRequest();
        }

        [HttpGet("GetAddressById/{addressId}")]
        public async Task<IActionResult> GetAddress([FromRoute] int addressId, CancellationToken cancellationToken)
        {
            var address = await _mediator.Send(new GetAddressByIdQueryRequest(addressId), cancellationToken);
            if (address != null)
            {
                return Ok(address);
            }
            return NotFound();
        }

        [HttpPut("UpdateAddress/{addressId}")]
        public async Task<IActionResult> UpdateAddress(int addressId, [FromForm] UpdateAddressDto updateAddress,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map(updateAddress, new UpdateAddressCommandRequest());
            command.AddressId = addressId;
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
            if (isSuccessful)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("DeleteAddress/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId, CancellationToken cancellationToken)
        {
            bool isSuccessful = await _mediator.Send(new DeleteAddressCommandRequest(addressId), cancellationToken);
            if (isSuccessful)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
