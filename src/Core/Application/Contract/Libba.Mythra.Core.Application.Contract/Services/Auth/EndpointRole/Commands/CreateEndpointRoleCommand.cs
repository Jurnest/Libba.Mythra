using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Commands;

public record CreateEndpointRoleCommand
(
    Guid EndpointId,
    Guid RoleId
) : ICommand<Guid>;
