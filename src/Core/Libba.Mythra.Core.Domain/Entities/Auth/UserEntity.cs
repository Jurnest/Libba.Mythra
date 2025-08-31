using System.ComponentModel.DataAnnotations;

namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class UserEntity : BaseEntity
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<UserRoleGroupEntity> UserRoleGroups { get; set; } = new List<UserRoleGroupEntity>();
}
