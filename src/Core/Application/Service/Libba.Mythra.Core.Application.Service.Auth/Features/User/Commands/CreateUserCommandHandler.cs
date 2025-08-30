using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Commands;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Shared.Helpers.Argon2;
using MediatR;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    #region Dependencies
    // IUnitOfWork bağımlılığı tamamen kaldırıldı!
    private readonly IWriteRepository<UserEntity> _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public CreateUserCommandHandler(
        IWriteRepository<UserEntity> userWriteRepository,
        IUserReadRepository userReadRepository,
        IMythraMapper mapper)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUserByEmail = await _userReadRepository.GetByEmailAsync(request.Email);
        if (existingUserByEmail is not null)
        {
            throw new InvalidOperationException($"Email address '{request.Email}' is already in use.");
        }

        UserEntity user = _mapper.Map<UserEntity>(request);

        user.Password = Argon2Helper.HashPassword(request.Password);
        user.IsActive = false;

        await _userWriteRepository.AddAsync(user);

        return user.Id;
    }
}
