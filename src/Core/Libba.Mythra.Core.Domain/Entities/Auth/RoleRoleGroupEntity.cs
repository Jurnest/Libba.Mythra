namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class RoleRoleGroupEntity : BaseEntity
{
    public Guid RoleId { get; set; }
    public virtual RoleEntity Role { get; set; } = null!;

    public Guid RoleGroupId { get; set; }
    public virtual RoleGroupEntity RoleGroup { get; set; } = null!;
}
