using Libba.Mythra.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Libba.Mythra.Core.Domain.Entities;

/// <summary>
/// Represents the base class for entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique Key Value
    /// </summary>
    [Key]
    [ColumnName("ID")]
    public Guid Id { get; set; }

    /// <summary>
    /// Who Created
    /// </summary>
    [ColumnName("CREATED_BY")]
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// When Created
    /// </summary>
    [ColumnName("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Who Updated
    /// </summary>
    [ColumnName("UPDATED_BY")]
    public Guid? UpdatedBy { get; set; }

    /// <summary>
    /// When Updated
    /// </summary>
    [ColumnName("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}