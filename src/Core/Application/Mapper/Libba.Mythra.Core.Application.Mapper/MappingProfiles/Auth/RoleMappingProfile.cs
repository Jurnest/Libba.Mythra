using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Role.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<CreateRoleCommand, RoleEntity>();
        CreateMap<UpdateRoleCommand, RoleEntity>();
        CreateMap<RoleEntity, RoleDto>();
    }
}
