using MediatR;

namespace ProductRegistry.Domain.Core.Messages
{
    public abstract class EventRequest : RequestBase, INotification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
