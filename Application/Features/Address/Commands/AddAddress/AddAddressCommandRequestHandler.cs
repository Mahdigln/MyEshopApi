using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Address.Commands.AddAddress;

public class AddAddressCommandRequestHandler : IRequestHandler<AddAddressCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;
    private readonly ICustomerRepository _customerRepository;

    public AddAddressCommandRequestHandler(IMapper mapper, IAddressRepository addressRepository, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }
    public async Task<bool> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var isCustomerExist = _customerRepository.IsCustomerExist(request.CustomerId, cancellationToken);
        if (isCustomerExist.Result)
        {
            var address = _mapper.Map<Domain.Models.Address>(request);
            await _addressRepository.Add(address, cancellationToken);
            await _addressRepository.Save();
            return true;
        }
        return false;

    }
}