using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Commands;

public record CreateRoleRoleGroupCommand
(
    Guid RoleId,
    Guid RoleGroupId
) : ICommand<Guid>;
