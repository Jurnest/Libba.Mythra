using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Queries;

public record GetAllRoleRoleGroupsQuery() : IQuery<List<RoleRoleGroupDto>>;
