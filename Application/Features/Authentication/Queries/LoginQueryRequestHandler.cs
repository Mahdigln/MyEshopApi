using Application.IRepositories;
using Application.Response.Authentication;
using MediatR;

namespace Application.Features.Authentication.Queries;

public class LoginQueryRequestHandler : IRequestHandler<LoginQueryRequest, TokenResponse>
{
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly ICustomerRepository _customerRepository;

    public LoginQueryRequestHandler(IJwtTokenGenerator jwtToken, ICustomerRepository customerRepository)
    {
        _jwtToken = jwtToken;
        _customerRepository = customerRepository;
    }
    public async Task<TokenResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
    {

        var customer = await _customerRepository.LoginCustomer(request, cancellationToken);
        if (customer is null)
        {
            return null;
        }

        var token = _jwtToken.GenerateToken(customer);
        return new TokenResponse(token);
    }
}