using MediatR;

namespace Application.Features.Address.Commands.AddAddress;

public class AddAddressCommandRequest : IRequest<bool>
{
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }

    public int CustomerId { get; set; }
}