using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;

public record DeleteEndpointCommand
(
    Guid Id
) : ICommand<bool>;
