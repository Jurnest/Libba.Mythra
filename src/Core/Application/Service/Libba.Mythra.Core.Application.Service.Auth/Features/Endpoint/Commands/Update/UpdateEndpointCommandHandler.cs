using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;
using Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Commands.Create;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Commands.Update;

public class UpdateEndpointCommandHandler : IRequestHandler<UpdateEndpointCommand, Guid>
{
    #region Dependencies
    private readonly IEndpointWriteRepository _endpointWriteRepository;
    private readonly IEndpointReadRepository _endpointReadRepository;
    private readonly IMythraMapper _mapper;
    private readonly ILogger<UpdateEndpointCommandHandler> _logger;


    public UpdateEndpointCommandHandler(
        IMythraMapper mapper,
        ILogger<UpdateEndpointCommandHandler> logger,
        IEndpointWriteRepository endpointWriteRepository,
        IEndpointReadRepository endpointReadRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _endpointWriteRepository = endpointWriteRepository;
        _endpointReadRepository = endpointReadRepository;
    }
    #endregion

    public async Task<Guid> Handle(UpdateEndpointCommand request, CancellationToken cancellationToken)
    {
        var dal = await _endpointReadRepository.GetByIdAsync(request.Id);

        if (dal is null)
        {
            throw new Exception($"Endpoint with ID {request.Id} was not found.");
        }

        _mapper.Map(request, dal);


        _endpointWriteRepository.Update(dal);

        return dal.Id;
    }
}
