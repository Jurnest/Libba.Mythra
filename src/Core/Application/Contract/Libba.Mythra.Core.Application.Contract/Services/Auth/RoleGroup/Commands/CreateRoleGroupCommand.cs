using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Commands;

public record CreateRoleGroupCommand
(
    string Name,
    string? Description
) : ICommand<Guid>;