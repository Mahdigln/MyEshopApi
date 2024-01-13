using Application.Response.Authentication;
using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public record RegisterCommandRequest(string FirstName, string LastName, string Email, string Password) : IRequest<TokenResponse>;