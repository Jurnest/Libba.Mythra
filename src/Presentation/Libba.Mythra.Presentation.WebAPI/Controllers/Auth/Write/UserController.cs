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
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        // TODO: GetUserById endpoint'i oluşturulduğunda CreatedAtAction kullanmak daha doğru olur.
        return Ok(new { UserId = userId });
    }

}
