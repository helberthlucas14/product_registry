using ProductRegistry.Application.UseCases.Categories.Response;
using ProductRegistry.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Application.UseCases.Categories.Request
{
    public class CreateCategoryRequest : CommandRequest<CategoryResponse>
    {
        public Guid OwnerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
