using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.User.Queries;

public record GetUserByIdQuery(
     Guid Id
) : IQuery<UserDto?>;
