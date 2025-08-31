namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class RoleGroupEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public virtual ICollection<RoleRoleGroupEntity> RoleRoleGroups { get; set; } = new List<RoleRoleGroupEntity>();
    public virtual ICollection<UserRoleGroupEntity> UserRoleGroups { get; set; } = new List<UserRoleGroupEntity>();
}