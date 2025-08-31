using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libba.Mythra.Presentation.WebAPI.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
public partial class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { UserId = userId });
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
