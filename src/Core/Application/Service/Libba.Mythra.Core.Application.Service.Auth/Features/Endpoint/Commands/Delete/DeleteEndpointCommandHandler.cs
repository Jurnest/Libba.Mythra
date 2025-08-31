using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.Endpoint;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;
using MediatR;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.Endpoint.Commands.Delete;

public class DeleteEndpointCommandHandler : IRequestHandler<DeleteEndpointCommand, bool>
{
    #region Dependencies
    private readonly IEndpointWriteRepository _endpointWriteRepository;
    private readonly IEndpointReadRepository _endpointReadRepository;
    private readonly IMythraMapper _mapper;

    public DeleteEndpointCommandHandler(
        IMythraMapper mapper, IEndpointWriteRepository endpointWriteRepository, IEndpointReadRepository endpointReadRepository)
    {
        _mapper = mapper;
        _endpointWriteRepository = endpointWriteRepository;
        _endpointReadRepository = endpointReadRepository;
    }
    #endregion

    public async Task<bool> Handle(DeleteEndpointCommand request, CancellationToken cancellationToken)
    {
        var dal = await _endpointReadRepository.GetByIdAsync(request.Id);

        if (dal is null)
        {
            return false;
        }

        _endpointWriteRepository.Delete(dal);

        return true;
    }
}
