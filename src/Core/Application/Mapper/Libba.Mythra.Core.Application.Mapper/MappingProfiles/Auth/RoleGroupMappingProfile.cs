using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.RoleGroup.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class RoleGroupMappingProfile : Profile
{
    public RoleGroupMappingProfile()
    {
        CreateMap<CreateRoleGroupCommand, RoleGroupEntity>();
        CreateMap<UpdateRoleGroupCommand, RoleGroupEntity>();
        CreateMap<RoleGroupEntity, RoleGroupDto>();
    }
}