namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class EndpointRoleEntity : BaseEntity
{
    public Guid EndpointId { get; set; }
    public virtual EndpointEntity Endpoint { get; set; } = null!;

    public Guid RoleId { get; set; }
    public virtual RoleEntity Role { get; set; } = null!;
}

