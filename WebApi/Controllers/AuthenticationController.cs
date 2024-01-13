using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Authentication;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromForm] RegisterDto registerDto, CancellationToken cancellationToken)
    {
        var command = new RegisterCommandRequest(registerDto.FirstName, registerDto.LastName, registerDto.Email, registerDto.Password);
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginDto loginDto, CancellationToken cancellationToken)
    {
        var query = new LoginQueryRequest(loginDto.Email, loginDto.Password);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);

    }
}

