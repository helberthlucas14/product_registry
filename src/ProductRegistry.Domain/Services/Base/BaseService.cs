using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services.Base;

namespace ProductRegistry.Domain.Services.Base
{
    public class BaseService : IBaseService
    {
        protected IHandler<DomainNotification> Notifications { get; }

        public BaseService(IHandler<DomainNotification> notifications)
        {
            Notifications = notifications;
        }
    }
}
