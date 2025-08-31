using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Queries;

public record GetAllEndpointRolesQuery() : IQuery<List<EndpointRoleDto>>;