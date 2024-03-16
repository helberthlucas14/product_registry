using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;

namespace ProductRegistry.Application.UseCases.ApiErrorLog.Handlers
{
    public class GetApiErrorLogUseCase : UseCaseBaseRequestToDomain<GetErrorsRequest, Domain.Models.ApiErrorLog, GetErrorsResponse>
    {
        public GetApiErrorLogUseCase(
            IHandler<DomainNotification> notifications,
            IMediator mediator,
            IApiErrorLogService baseService,
            IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
        }

        public override async Task<GetErrorsResponse> HandleSafeMode(GetErrorsRequest request, CancellationToken cancellationToken)
        {
            var entities = await BaseDomainService.GetAllQuery
                .Where(x => x.Timestamp >= request.StartDate && x.Timestamp <= request.EndDate)
                .ToListAsync(cancellationToken);

            var response = new GetErrorsResponse
            {
                Data = Mapper.Map<List<ApiErrorLogResponse>>(entities),
                Format = request.Format
            };

            return response.FormaterReport();
        }
    }
}
