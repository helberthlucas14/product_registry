using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Application.UseCases.ApiErrorLog.Request
{
    public class ApiErrorLogRequest : CommandRequest<ApiErrorLogResponse>
    {
        public string RootCause { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ExceptionStackTrace { get; set; } = string.Empty;
    }
}
