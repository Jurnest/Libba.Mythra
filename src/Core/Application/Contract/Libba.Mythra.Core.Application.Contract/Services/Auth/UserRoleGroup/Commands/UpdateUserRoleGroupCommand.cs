using Libba.Mythra.Core.Application.Contract.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Commands;

public record UpdateUserRoleGroupCommand
(
    Guid Id,
    Guid UserId,
    Guid RoleGroupId
) : ICommand<Guid>;

