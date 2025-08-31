using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using MediatR;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    #region Dependencies
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public UpdateUserCommandHandler(
        IUserWriteRepository userWriteRepository,
        IUserReadRepository userReadRepository,
        IMythraMapper mapper)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userReadRepository.GetByIdAsync(request.Id);

        if (userToUpdate is null)
        {
            throw new Exception($"User with ID {request.Id} was not found.");
        }

        _mapper.Map(request, userToUpdate);


        _userWriteRepository.Update(userToUpdate);

        return userToUpdate.Id;
    }
}