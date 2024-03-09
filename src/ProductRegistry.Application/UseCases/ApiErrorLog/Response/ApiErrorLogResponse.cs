using ProductRegistry.Domain.Core.Messages;

namespace ProductRegistry.Application.UseCases.ApiErrorLog.Response
{
    public class ApiErrorLogResponse : ResponseBase
    {
        public string RootCause { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } = string.Empty;
        public string ExceptionStackTrace { get; set; } = string.Empty;
    }
}
