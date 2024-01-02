using Application.IRepositories;
using Application.Response.Address;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Queries.GetAddressByCustomerId;

public class GetAddressByICustomerIdQueryRequestHandler : IRequestHandler<GetAddressByICustomerIdQueryRequest,
    List<AddressQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressByICustomerIdQueryRequestHandler(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }
    public async Task<List<AddressQueryResponse>> Handle(GetAddressByICustomerIdQueryRequest request, CancellationToken cancellationToken)
    {
        var listAddress = await _addressRepository.GetAddressByCustomerId(request.CustomerId,cancellationToken);
        if (listAddress is not null)
        {
            var addressModel = _mapper.Map<List<AddressQueryResponse>>(listAddress);
            return addressModel;

        }
        return null;
    }
}