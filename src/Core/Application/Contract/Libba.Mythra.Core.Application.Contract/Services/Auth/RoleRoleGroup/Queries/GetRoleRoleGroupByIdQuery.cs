using Libba.Mythra.Core.Application.Contract.CQRS;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Queries;

public record GetRoleRoleGroupByIdQuery
(
    Guid Id
) : IQuery<RoleRoleGroupDto?>;