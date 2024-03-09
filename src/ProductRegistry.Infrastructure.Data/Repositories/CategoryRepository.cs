using MongoDB.Driver;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDatabase database) : base(database)
        {
        }

        public async Task<Category> GetByTitleAsync(string title)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Title, title);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
