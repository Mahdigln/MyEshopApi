using Application.IRepositories;
using Application.Response.Address;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Queries.GetAddressById;

public class GetAddressByIdQueryRequestHandler : IRequestHandler<GetAddressByIdQueryRequest, AddressQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressByIdQueryRequestHandler(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }
    public async Task<AddressQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.Get(request.AddressId, cancellationToken);
        if (address is not null)
        {
            var addressModel = _mapper.Map<AddressQueryResponse>(address);
            return addressModel;
        }

        return null;
    }
}