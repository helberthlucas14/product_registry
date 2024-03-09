using MediatR;

namespace ProductRegistry.Domain.Core.Messages
{
    public abstract class CommandRequest<TResponse> : RequestBase, IRequest<TResponse>
    {

    }
}
