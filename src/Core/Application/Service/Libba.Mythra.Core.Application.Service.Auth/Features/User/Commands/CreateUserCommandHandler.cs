using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Commands;
using Libba.Mythra.Core.Domain.Entities.Auth;
using Libba.Mythra.Shared.Helpers.Argon2;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    #region Dependencies
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserReadRepository userReadRepository, IMythraMapper mapper)
    {
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.GetWriteRepository<UserEntity>().AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }
}

