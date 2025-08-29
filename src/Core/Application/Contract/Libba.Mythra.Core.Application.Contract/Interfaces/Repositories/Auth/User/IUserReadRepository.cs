using Libba.Mythra.Core.Application.Contract.Interfaces.Repositories;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;

/// <summary>
/// Defines the contract for the repository responsible for reading User data.
/// Inherits generic read operations and adds user-specific query methods.
/// </summary>
public interface IUserReadRepository : IReadRepository<UserEntity>
{
    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    Task<UserEntity?> GetByEmailAsync(string email);
}
