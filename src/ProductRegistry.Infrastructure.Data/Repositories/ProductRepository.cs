using MongoDB.Driver;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Models;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Middlewares;

namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDatabase database, IOwnerService tenant) : base(database, tenant)
        {
        }

        public Task<Product> GetByOwnerIdProjectId(Guid ownerId, Guid projectId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.OwnerId, ownerId)
              & Builders<Product>.Filter.Eq(x => x.Id, projectId);

            return Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}