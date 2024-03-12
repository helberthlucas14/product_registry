using ProductRegistry.Application.UseCases.Categories.Response;
using ProductRegistry.Domain.Core.Messages;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductRegistry.Application.UseCases.Categories.Request
{
    public class UpdateCategoryRequest : CommandRequest<CategoryResponse>
    {
        [NotMapped]
        public Guid Id { get; private set; }
        public Guid OwnerId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;


        public UpdateCategoryRequest SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
