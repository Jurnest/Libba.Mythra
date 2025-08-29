using Libba.Mythra.Core.Application.Contract.Services.Auth.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Libba.Mythra.Presentation.WebAPI.Controllers.Auth;

public partial class UserController
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var users = await _mediator.Send(query);
        return Ok(users);
    }
}