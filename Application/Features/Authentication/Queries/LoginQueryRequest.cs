using Application.Response.Authentication;
using MediatR;

namespace Application.Features.Authentication.Queries;

public record LoginQueryRequest(string Email, string Password) : IRequest<TokenResponse>;