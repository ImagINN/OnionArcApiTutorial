using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArc.Application.Features.Auth.Command.Login;
using OnionArc.Application.Features.Auth.Command.RefreshToken;
using OnionArc.Application.Features.Auth.Command.Register;

namespace OnionArc.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        LoginCommandResponse response = await mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK, response);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
    {
        RefreshTokenCommandResponse response = await mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK, response);
    }
}
