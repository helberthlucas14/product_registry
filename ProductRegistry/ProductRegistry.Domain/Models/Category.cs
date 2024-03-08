using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Domain.Models
{
    public class Category : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
