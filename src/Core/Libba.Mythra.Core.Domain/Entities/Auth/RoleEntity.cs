namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class RoleEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public virtual ICollection<EndpointRoleEntity> EndpointRoles { get; set; } = new List<EndpointRoleEntity>();
    public virtual ICollection<RoleRoleGroupEntity> RoleRoleGroups { get; set; } = new List<RoleRoleGroupEntity>();
}
