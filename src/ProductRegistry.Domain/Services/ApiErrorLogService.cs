using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Repositories.Base;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Validation;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Services.Base;

namespace ProductRegistry.Domain.Services
{
    public class ApiErrorLogService : BaseServiceValidation<ApiErrorLog>, IApiErrorLogService
    {
        public ApiErrorLogService(IBaseRepository<ApiErrorLog> baseRepository,
            IHandler<DomainNotification> notifications,
            IRegisterValidation<ApiErrorLog> registerValidation)
            : base(baseRepository, notifications, registerValidation)
        {
        }
    }
}