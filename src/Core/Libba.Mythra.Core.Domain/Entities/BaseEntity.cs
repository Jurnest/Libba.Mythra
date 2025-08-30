﻿namespace Libba.Mythra.Core.Domain.Entities;

/// <summary>
/// Represents the base class for entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique Key Value
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Who Created
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// When Created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Who Updated
    /// </summary>
    public Guid? UpdatedBy { get; set; }

    /// <summary>
    /// When Updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}