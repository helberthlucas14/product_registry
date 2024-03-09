using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IMongoRepository<Category>
    {
        public Task<Category> GetByTitleAsync(string title);
    }
}
