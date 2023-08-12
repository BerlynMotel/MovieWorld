using MediatR;

namespace movie.application.Abstractions.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> { }
