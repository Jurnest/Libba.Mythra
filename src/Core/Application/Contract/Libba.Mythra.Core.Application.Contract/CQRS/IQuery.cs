﻿using MediatR;

namespace Libba.Mythra.Core.Application.Contract.CQRS;

/// <summary>
/// Represents a query that returns a response.
/// Provides semantic clarity on top of MediatR's IRequest.
/// </summary>
public interface IQuery<out TResponse> : IRequest<TResponse> { }

