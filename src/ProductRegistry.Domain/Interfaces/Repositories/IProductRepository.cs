using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IMongoRepository<Product>
    {
        public Task<Product> GetByOwnerIdProjectId(Guid ownerId, Guid projectId);
    }
}
