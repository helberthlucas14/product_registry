using MediatR;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Messages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductRegistry.Application.UseCases.Products.Request
{
    public class UpdateProjectRequest : CommandRequest<ProductResponse>
    {
        [JsonIgnore]
        public Guid Id { get; private set; }
        public Guid OwnerId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public double? Price { get; set; } = null;

        public UpdateProjectRequest SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
