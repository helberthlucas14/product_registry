using System.Text.Json.Serialization;

namespace ProductRegistry.Domain.Core.Messages
{
    public abstract class RequestBase
    {
        [JsonIgnore]
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    }
}
