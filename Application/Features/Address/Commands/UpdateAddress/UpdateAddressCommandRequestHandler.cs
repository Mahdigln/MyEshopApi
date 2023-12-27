using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Commands.UpdateAddress;

public class UpdateAddressCommandRequestHandler : IRequestHandler<UpdateAddressCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public UpdateAddressCommandRequestHandler(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }
    public async Task<bool> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.Get(request.AddressId, cancellationToken);
        if (address is not null)
        {
            var updatedAddress = _mapper.Map(request, address);
            _addressRepository.Update(updatedAddress);
            await _addressRepository.Save();
            return true;
        }

        return false;

    }
}