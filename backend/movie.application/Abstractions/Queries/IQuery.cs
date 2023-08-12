using MediatR;

namespace movie.application.Abstractions.Queries;

public interface IQuery<out TResult> : IRequest<TResult> { }
