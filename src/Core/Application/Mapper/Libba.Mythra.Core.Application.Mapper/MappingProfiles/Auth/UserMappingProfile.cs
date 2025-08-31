using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.User.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
        CreateMap<UserEntity, UserDto>();
    }
}