using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IMongoRepository<Product>
    {

    }
}
