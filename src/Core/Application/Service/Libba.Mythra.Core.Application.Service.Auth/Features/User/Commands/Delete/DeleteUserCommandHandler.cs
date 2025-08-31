using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;
using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Application.Contract.Interfaces;
using Libba.Mythra.Core.Domain.Entities.Auth;
using MediatR;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;

namespace Libba.Mythra.Core.Application.Service.Auth.Features.User.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    #region Dependencies
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IMythraMapper _mapper;

    public DeleteUserCommandHandler(
        IUserWriteRepository userWriteRepository,
        IUserReadRepository userReadRepository,
        IMythraMapper mapper)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var dal = await _userReadRepository.GetByIdAsync(request.Id);

        if (dal is null)
        {
            return false;
        }

        _userWriteRepository.Delete(dal);

        return true;
    }
}
