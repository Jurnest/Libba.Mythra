using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleRoleGroup.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class RoleRoleGroupMappingProfile : Profile
{
    public RoleRoleGroupMappingProfile()
    {
        CreateMap<CreateRoleRoleGroupCommand, RoleRoleGroupEntity>();
        CreateMap<UpdateRoleRoleGroupCommand, RoleRoleGroupEntity>();
        CreateMap<RoleRoleGroupEntity, RoleRoleGroupDto>();
    }
}