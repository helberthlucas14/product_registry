namespace ProductRegistry.Application.UseCases.Products.Response
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public Guid? CategoryId { get; private set; } = Guid.Empty;
    }
}
