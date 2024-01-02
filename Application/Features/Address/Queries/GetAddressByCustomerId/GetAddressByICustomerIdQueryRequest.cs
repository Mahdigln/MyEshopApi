using Application.Response.Address;
using MediatR;

namespace Application.Features.Address.Queries.GetAddressByCustomerId;

public record GetAddressByICustomerIdQueryRequest(int CustomerId) : IRequest<List<AddressQueryResponse>>;