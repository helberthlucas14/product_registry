using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace ProductRegistry.Application.UseCases.Products.Request
{
    public class CreateProductRequest : CommandRequest<ProductResponse>
    {
        public Guid OwnerId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
