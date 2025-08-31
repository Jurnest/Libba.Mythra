using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Dtos;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Queries;

public class GetAllEndpointsQueryHandler : IRequestHandler<GetAllEndpointsQuery, IEnumerable<EndpointDto>>
{
    #region Dependencies
    private readonly IEndpointReadRepository _endpointReadRepository;
    private readonly IMythraMapper _mapper;
    private readonly ILogger<GetAllEndpointsQueryHandler> _logger;


    public GetAllEndpointsQueryHandler(
        IMythraMapper mapper,
        ILogger<GetAllEndpointsQueryHandler> logger,
        IEndpointReadRepository endpointReadRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _endpointReadRepository = endpointReadRepository;
    }
    #endregion

    public async Task<IEnumerable<EndpointDto>> Handle(GetAllEndpointsQuery request, CancellationToken cancellationToken)
    {
        var datas = await _endpointReadRepository.GetAllAsync();
        var dal = _mapper.Map<IEnumerable<EndpointDto>>(datas);

        return dal;
    }
}
