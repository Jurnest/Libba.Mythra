using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Dtos;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Queries;
using Libba.Mythra.Core.Domain.Entities.Auth;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    #region Dependencies
    private readonly ILogger<GetUserByIdQueryHandler> _logger;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public GetUserByIdQueryHandler(IUserReadRepository userReadRepository, IMythraMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _userReadRepository.GetByIdAsync(request.Id);
        var dal = _mapper.Map<UserDto>(data);

        return dal;
    }
}
