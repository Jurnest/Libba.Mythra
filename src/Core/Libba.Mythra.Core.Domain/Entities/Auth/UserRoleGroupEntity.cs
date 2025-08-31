using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Core.Domain.Entities.Auth;

public class UserRoleGroupEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual UserEntity User { get; set; } = null!;

    public Guid RoleGroupId { get; set; }
    public virtual RoleGroupEntity RoleGroup { get; set; } = null!;
}

