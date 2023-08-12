using MediatR;

namespace movie.application.Abstractions.Commands;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse> { }
