using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Commands;

public record DeleteEndpointRoleCommand
(
    Guid Id
) : ICommand<bool>;

