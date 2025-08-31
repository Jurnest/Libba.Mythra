using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Domain.Enums;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;

public record CreateEndpointCommand
(
    string ControllerName,
    string ActionName,
    HttpVerb HttpVerb,
    string Path
) : ICommand<Guid>;
