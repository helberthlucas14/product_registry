using MediatR;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Domain.Core.Notications;


namespace ProductRegistry.Application.Events.Base
{
    public abstract class EventHandlerBase<TEvent> : INotificationHandler<TEvent>
            where TEvent : EventRequest, new()
    {
        protected IHandler<DomainNotification> Notifications { get; }

        protected EventHandlerBase(IHandler<DomainNotification> notifications)
        {
            Notifications = notifications;
        }

        protected bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            return true;
        }

        protected async Task<bool> CommitAsync()
        {
            if (Notifications.HasNotifications())
                return false;

            return true;
        }

        public virtual Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
