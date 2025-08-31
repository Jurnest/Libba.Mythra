using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.User.Queries;

/// <summary>
/// Represents the query to retrieve all users.
/// Returns a list of UserDto.
/// </summary>
public record GetAllUsersQuery() : IQuery<IEnumerable<UserDto>>;
