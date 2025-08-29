namespace Libba.Mythra.Core.Domain.Common;

[AttributeUsage(AttributeTargets.Class)]
public class TableNameAttribute : Attribute
{
    public string Name { get; }

    public TableNameAttribute(string name)
    {
        Name = name;
    }

}