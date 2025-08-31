using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.UserRoleGroup.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class UserRoleGroupMappingProfile : Profile
{
    public UserRoleGroupMappingProfile()
    {
        CreateMap<CreateUserRoleGroupCommand, UserRoleGroupEntity>();
        CreateMap<UpdateUserRoleGroupCommand, UserRoleGroupEntity>();
        CreateMap<UserRoleGroupEntity, UserRoleGroupDto>();
    }
}