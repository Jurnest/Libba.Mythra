using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.EndpointRole.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class EndpointRoleMappingProfile : Profile
{
    public EndpointRoleMappingProfile()
    {
        CreateMap<CreateEndpointRoleCommand, EndpointRoleEntity>();
        CreateMap<UpdateEndpointRoleCommand, EndpointRoleEntity>();
        CreateMap<EndpointRoleEntity, EndpointRoleDto>();
    }
}