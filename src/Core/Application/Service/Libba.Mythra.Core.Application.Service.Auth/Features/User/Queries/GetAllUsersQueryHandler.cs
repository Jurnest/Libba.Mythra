using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Dtos;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Queries;
using Libba.Mythra.Core.Domain.Entities.Auth;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    #region Dependencies
    private readonly ILogger<GetAllUsersQueryHandler> _logger;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository, IMythraMapper mapper, ILogger<GetAllUsersQueryHandler> logger)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<UserEntity> users = await _userReadRepository.GetAllAsync();
        IEnumerable<UserDto> userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

        return userDtos;
    }
}
