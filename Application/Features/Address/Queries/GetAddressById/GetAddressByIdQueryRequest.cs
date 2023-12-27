using Application.Response.Address;
using MediatR;

namespace Application.Features.Address.Queries.GetAddressById;

public record GetAddressByIdQueryRequest(int AddressId) : IRequest<AddressQueryResponse>;