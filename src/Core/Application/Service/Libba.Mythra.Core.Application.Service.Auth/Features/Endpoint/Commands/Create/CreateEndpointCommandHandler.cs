using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;
using Libba.Mythra.Core.Domain.Entities.Auth;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Commands.Create;

public class CreateEndpointCommandHandler : IRequestHandler<CreateEndpointCommand, Guid>
{
    #region Dependencies
    private readonly IEndpointWriteRepository _endpointWriteRepository;
    private readonly IMythraMapper _mapper;
    private readonly ILogger<CreateEndpointCommandHandler> _logger;


    public CreateEndpointCommandHandler(
        IMythraMapper mapper,
        ILogger<CreateEndpointCommandHandler> logger,
        IEndpointWriteRepository endpointWriteRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _endpointWriteRepository = endpointWriteRepository;
    }
    #endregion

    public async Task<Guid> Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
    {
        var dal = _mapper.Map<EndpointEntity>(request);

        await _endpointWriteRepository.AddAsync(dal);

        return dal.Id;
    }
}
