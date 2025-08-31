using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Dtos;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Queries;

public record GetAllEndpointsQuery() : IQuery<List<EndpointDto>>;
