using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Queries;

public record GetEndpointRoleByIdQuery
(
    Guid Id
) : IQuery<EndpointRoleDto?>;