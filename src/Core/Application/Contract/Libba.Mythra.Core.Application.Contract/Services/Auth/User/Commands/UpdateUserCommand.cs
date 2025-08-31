using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;

public record UpdateUserCommand(
    Guid Id,
    string Name,
    string Surname,
    string Email) : ICommand<Guid>;
