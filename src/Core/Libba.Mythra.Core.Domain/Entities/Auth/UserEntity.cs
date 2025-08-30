using System.ComponentModel.DataAnnotations;

namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class UserEntity : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public bool IsActive { get; set; }
}
