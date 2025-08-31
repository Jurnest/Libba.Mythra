using Libba.Mythra.Core.Application.Contract.CQRS;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;

/// <summary>
/// Represents the command with data for creating a new user.
/// Returns the new user's Guid upon successful execution.
/// </summary>
public record CreateUserCommand(
    string Name,
    string Surname,
    string Email,
    string Password) : ICommand<Guid>;
