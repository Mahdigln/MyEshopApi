using Application.IRepositories;
using Application.Response.Authentication;
using Application.Utilities;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public class RegisterCommandRequestHandler : IRequestHandler<RegisterCommandRequest, TokenResponse>
{
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public RegisterCommandRequestHandler(IJwtTokenGenerator jwtToken, ICustomerRepository customerRepository, IMapper mapper)
    {
        _jwtToken = jwtToken;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<TokenResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        var customerEmail = await _customerRepository.IsEmailExist(request.Email, cancellationToken);
        if (customerEmail)
        {
            return null;
        }
        var customer = _mapper.Map<Customer>(request);
        customer.Password = PasswordHelper.EncodePasswordMd5(request.Password);
        customer.Email = FixedText.FiXEmail(request.Email);
        await _customerRepository.Add(customer, cancellationToken);
        await _customerRepository.Save();
        var token = _jwtToken.GenerateToken(customer);
        return new TokenResponse(token);
    }
}