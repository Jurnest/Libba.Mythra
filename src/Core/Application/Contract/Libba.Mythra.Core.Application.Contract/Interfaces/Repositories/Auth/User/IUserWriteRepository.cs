using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Contract.Interfaces.Repositories.Auth.User;

/// <summary>
/// Defines the contract for the repository responsible for writing User data.
/// Inherits generic write operations and can include user-specific write methods.
/// </summary>
public interface IUserWriteRepository : IWriteRepository<UserEntity>
{
}
