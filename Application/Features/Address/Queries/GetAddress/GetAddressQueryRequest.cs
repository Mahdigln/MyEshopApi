using Application.Response.Address;
using MediatR;

namespace Application.Features.Address.Queries.GetAddress;

public record GetAddressQueryRequest : IRequest<List<AddressQueryResponse>>;