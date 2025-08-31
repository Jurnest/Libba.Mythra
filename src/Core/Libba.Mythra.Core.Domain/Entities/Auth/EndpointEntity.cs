using Libba.Mythra.Core.Domain.Enums;

namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class EndpointEntity : BaseEntity
{
    public string ControllerName { get; set; } = string.Empty;
    public string ActionName { get; set; } = string.Empty;
    public HttpVerb HttpVerb { get; set; }
    public string Path { get; set; } = string.Empty;

    public virtual ICollection<EndpointRoleEntity> EndpointRoles { get; set; } = new List<EndpointRoleEntity>();
}
