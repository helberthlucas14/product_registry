using MongoDB.Driver;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Models;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Middlewares;

namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDatabase database, IOwnerService service) : base(database, service)
        {
        }

        public Task<Category> GetByOwnerICategoryIdAsync(Guid ownerId, Guid id)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.OwnerId, ownerId)
                & Builders<Category>.Filter.Eq(x => x.Id, id);

            return Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Category> GetByTitleAsync(string title)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Title, title);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
