using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Domain.Models
{
    public class Product : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public virtual Category Category { get; private set; } = new Category();
        public Guid CategoryId { get; private set; } = Guid.Empty;
    }

}
