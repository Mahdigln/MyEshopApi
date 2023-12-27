using MediatR;

namespace Application.Features.Address.Commands.UpdateAddress;

public class UpdateAddressCommandRequest : IRequest<bool>
{
    public int AddressId { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
}