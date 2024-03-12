using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Enums;

namespace ProductRegistry.Application.UseCases.ApiErrorLog.Request
{
    public class GetErrorsRequest : CommandRequest<GetErrorsResponse>
    {
        public Guid OwnerId { get; set; }
        public ReportFormat Format { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
