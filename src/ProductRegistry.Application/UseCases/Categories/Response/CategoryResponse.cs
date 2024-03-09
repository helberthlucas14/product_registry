using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Application.UseCases.Categories.Response
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }  
        public Guid OwnerId { get; set; }  
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
