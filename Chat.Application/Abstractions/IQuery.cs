using Chat.Core;
using MediatR;


namespace Chat.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
