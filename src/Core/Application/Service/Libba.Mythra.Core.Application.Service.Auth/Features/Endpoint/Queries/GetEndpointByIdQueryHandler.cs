using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Dtos;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Queries;

public class GetEndpointByIdQueryHandler : IRequestHandler<GetEndpointByIdQuery, EndpointDto>
{
    #region Dependencies
    private readonly IEndpointReadRepository _endpointReadRepository;
    private readonly IMythraMapper _mapper;
    private readonly ILogger<GetEndpointByIdQueryHandler> _logger;


    public GetEndpointByIdQueryHandler(
        IMythraMapper mapper,
        ILogger<GetEndpointByIdQueryHandler> logger,
        IEndpointReadRepository endpointReadRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _endpointReadRepository = endpointReadRepository;
    }
    #endregion

    public async Task<EndpointDto> Handle(GetEndpointByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _endpointReadRepository.GetByIdAsync(request.Id);
        var dal = _mapper.Map<EndpointDto>(data);

        return dal;
    }
}
