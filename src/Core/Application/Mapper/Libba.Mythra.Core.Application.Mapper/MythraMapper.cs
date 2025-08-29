using AutoMapper;
using Libba.Mythra.Core.Application.Contract.Interfaces;

namespace Libba.Mythra.Core.Application.Mapper;

public class MythraMapper : IMythraMapper
{
    private readonly IMapper _mapper;

    public MythraMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TDestination>(object source)
    {
        return _mapper.Map<TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        return _mapper.Map(source, destination);
    }

    public IEnumerable<TDestination> MapEnumerable<TDestination>(IEnumerable<object> source)
    {
        return _mapper.Map<IEnumerable<TDestination>>(source);
    }
}

