using ProductRegistry.Domain.Events;
using ProductRegistry.Domain.Interfaces.Services;

namespace ProductRegistry.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private Guid _ownerId;
        public Guid OwnerId => _ownerId;
        public OwnerService() { }
        public OwnerService(Guid tenantId) => _ownerId = tenantId;

        public event OwnerChangedEventHandler OnOwnerChanged = null!;

        public Task SetOwnerId(Guid ownerId)
        {
            if (ownerId != _ownerId)
            {
                var old = _ownerId;
                _ownerId = ownerId;
                OnOwnerChanged?.Invoke(this, new OwnerChangedEventArgs(old, _ownerId));
            }

            return Task.CompletedTask;
        }
    }
}