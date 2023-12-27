using Application.IRepositories;
using Application.Response.Address;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Queries.GetAddress;

public class GetAddressQueryRequestHandler : IRequestHandler<GetAddressQueryRequest, List<AddressQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressQueryRequestHandler(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }
    public async Task<List<AddressQueryResponse>> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
    {
        var listAddress = await _addressRepository.GetAll(cancellationToken);
        if (listAddress is not null)
        {
            var addressModel = _mapper.Map<List<AddressQueryResponse>>(listAddress);
            return addressModel;

        }
        return null;
    }
}