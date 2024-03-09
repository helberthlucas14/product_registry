using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Domain.Models
{
    public class ApiErrorLog : Entity
    {
        public string RootCause { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } = string.Empty;
        public string ExceptionStackTrace { get; set; } = string.Empty;
    }

}
