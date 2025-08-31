using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Commands;

public record DeleteRoleRoleGroupCommand
(
Guid Id
) : ICommand<bool>;