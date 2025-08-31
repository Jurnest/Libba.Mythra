using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Commands;

public record UpdateRoleGroupCommand
(
    Guid Id,
    string Name,
    string? Description
) : ICommand<Guid>;
