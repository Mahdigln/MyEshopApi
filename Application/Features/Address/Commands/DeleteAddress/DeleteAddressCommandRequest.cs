using MediatR;

namespace Application.Features.Address.Commands.DeleteAddress;

public record DeleteAddressCommandRequest(int AddressId) : IRequest<bool>;