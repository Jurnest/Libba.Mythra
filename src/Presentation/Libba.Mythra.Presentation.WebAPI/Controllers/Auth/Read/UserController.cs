using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Libba.Mythra.Presentation.WebAPI.Controllers.Auth;

public partial class UserController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUsersQuery();
        var users = await _mediator.Send(query);
        return Ok(users);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var users = await _mediator.Send(Id);
        return Ok(users);
    }
}