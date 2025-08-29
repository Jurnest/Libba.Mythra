using Dapper;
using Libba.Mythra.Core.Domain.Common;
using System.Reflection;

namespace Libba.Mythra.Infrastructure.Persistence.Dapper.Mapping;

public class ColumnAttributeTypeMapper<T> : FallbackTypeMapper
{
    public ColumnAttributeTypeMapper()
        : base(new SqlMapper.ITypeMap[]
        {
                new CustomPropertyTypeMap(typeof(T),
                    (type, columnName) => type.GetProperties().FirstOrDefault(prop =>
                        prop.GetCustomAttributes(false)
                            .OfType<ColumnNameAttribute>()
                            .Any(attr => attr.Name == columnName))),
                new DefaultTypeMap(typeof(T))
        })
    {
    }
}

public class FallbackTypeMapper : SqlMapper.ITypeMap
{
    private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;
    public FallbackTypeMapper(IEnumerable<SqlMapper.ITypeMap> mappers)
    {
        _mappers = mappers;
    }

    public ConstructorInfo FindConstructor(string[] names, Type[] types) =>
        _mappers.Select(m => m.FindConstructor(names, types))
                .FirstOrDefault(c => c != null);

    public ConstructorInfo FindExplicitConstructor() =>
        _mappers.Select(m => m.FindExplicitConstructor())
                .FirstOrDefault(c => c != null);

    public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName) =>
         _mappers.Select(m => m.GetConstructorParameter(constructor, columnName))
                 .FirstOrDefault(p => p != null);

    public SqlMapper.IMemberMap GetMember(string columnName) =>
         _mappers.Select(m => m.GetMember(columnName))
                 .FirstOrDefault(p => p != null);
}