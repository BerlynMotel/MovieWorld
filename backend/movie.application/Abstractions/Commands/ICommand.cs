using MediatR;

namespace movie.application.Abstractions.Commands;

public interface ICommand : IRequest { }

public interface ICommand<out TResponse> : IRequest<TResponse> { }  