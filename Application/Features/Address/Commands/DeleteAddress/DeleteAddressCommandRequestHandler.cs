using Application.IRepositories;
using MediatR;

namespace Application.Features.Address.Commands.DeleteAddress;

public class DeleteAddressCommandRequestHandler : IRequestHandler<DeleteAddressCommandRequest, bool>
{
    private readonly IAddressRepository _addressRepository;

    public DeleteAddressCommandRequestHandler(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    public async Task<bool> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.Get(request.AddressId, cancellationToken);
        if (address is not null)
        {
            _addressRepository.Delete(address);
            await _addressRepository.Save();
            return true;
        }
        return false;
    }
}