namespace Libba.Mythra.Core.Application.Contract.Interfaces;

public interface IMythraMapper
{
    TDestination Map<TDestination>(object source);
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    IEnumerable<TDestination> MapEnumerable<TDestination>(IEnumerable<object> source);
}
