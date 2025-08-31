namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Dtos;

public class RoleGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}