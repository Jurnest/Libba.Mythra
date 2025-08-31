using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Commands;

public record CreateUserRoleGroupCommand
(
    Guid UserId,
    Guid RoleGroupId
) : ICommand<Guid>;
