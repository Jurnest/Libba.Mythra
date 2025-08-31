using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;
public record class DeleteUserCommand(
    Guid Id) : ICommand<bool>;
