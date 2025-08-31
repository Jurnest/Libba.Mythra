using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Commands;

public record UpdateRoleCommand
(
    Guid Id,
    string Name,
    string? Description
) : ICommand<Guid>;