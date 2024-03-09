using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Messages;

namespace ProductRegistry.Application.UseCases.Products.Queries
{
    public class GetAllProductsQuerie : CommandRequest<IEnumerable<ProductResponse>>
    {
    }
}
