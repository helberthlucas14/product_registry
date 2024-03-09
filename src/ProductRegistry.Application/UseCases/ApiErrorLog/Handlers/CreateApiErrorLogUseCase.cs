using AutoMapper;
using MediatR;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;


namespace ProductRegistry.Application.UseCases.ApiErrorLog.Handlers
{
    public class CreateApiErrorLogUseCase : UseCaseBaseRequestToDomain<ApiErrorLogRequest, Domain.Models.ApiErrorLog, ApiErrorLogResponse>
    {
        public CreateApiErrorLogUseCase(
            IHandler<DomainNotification> notifications,
            IMediator mediator,
            IApiErrorLogService baseService,
            IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
        }

        public override async Task<ApiErrorLogResponse> HandleSafeMode(ApiErrorLogRequest request, CancellationToken cancellationToken)
            => await RegisterAsync(request);

    }
}
