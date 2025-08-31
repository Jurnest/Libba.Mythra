using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Queries;

public record GetAllUserRoleGroupsQuery() : IQuery<List<UserRoleGroupDto>>;

