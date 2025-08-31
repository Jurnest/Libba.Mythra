using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Commands;

public record DeleteRoleCommand
(
    Guid Id
) : ICommand<bool>;