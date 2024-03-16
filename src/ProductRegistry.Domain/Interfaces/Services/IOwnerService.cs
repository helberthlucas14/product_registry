using ProductRegistry.Domain.Events;

namespace ProductRegistry.Domain.Interfaces.Services
{
    public delegate void OwnerChangedEventHandler(object source, OwnerChangedEventArgs args);
    public interface IOwnerService
    {
        Guid OwnerId { get; }
        Task SetOwnerId(Guid tenantId);

        event OwnerChangedEventHandler OnOwnerChanged;
    }
}
