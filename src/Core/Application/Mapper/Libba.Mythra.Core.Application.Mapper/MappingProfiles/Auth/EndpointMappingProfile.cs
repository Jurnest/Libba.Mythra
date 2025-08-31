using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Commands;
using Libba.Mythra.Core.Application.Contract.Services.Auth.Endpoint.Dtos;
using Libba.Mythra.Core.Domain.Entities.Auth;

namespace Libba.Mythra.Core.Application.Mapper.MappingProfiles.Auth;

public class EndpointMappingProfile : Profile
{
    public EndpointMappingProfile()
    {
        CreateMap<CreateEndpointCommand, EndpointEntity>();
        CreateMap<UpdateEndpointCommand, EndpointEntity>();
        CreateMap<EndpointEntity, EndpointDto>();
    }
}