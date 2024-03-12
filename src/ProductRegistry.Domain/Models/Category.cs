using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Domain.Models
{
    public class Category : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void Update(string title, string descrition)
        {
            Title = string.IsNullOrEmpty(title) ? Title : title;
            Description = string.IsNullOrEmpty(descrition) ? Title : descrition;
            ModifyAt = DateTime.Now;
        }
    }

}
