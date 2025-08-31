using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Queries;

public record GetRoleGroupByIdQuery
(
    Guid Id
) : IQuery<RoleGroupDto?>;