using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Queries;

public record GetRoleByIdQuery
(
    Guid Id
) : IQuery<RoleDto?>;