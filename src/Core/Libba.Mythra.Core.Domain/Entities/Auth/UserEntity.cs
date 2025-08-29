using Libba.Mythra.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Libba.Mythra.Core.Domain.Entities.Auth;

[TableName("AUTH_USER")]
public class UserEntity : BaseEntity
{
    [ColumnName("NAME")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [ColumnName("SURNAME")]
    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [ColumnName("EMAIL")]
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [ColumnName("PASSWORD")]
    [Required]
    public string Password { get; set; }

    [ColumnName("IS_ACTIVE")]
    public bool IsActive { get; set; }
}
