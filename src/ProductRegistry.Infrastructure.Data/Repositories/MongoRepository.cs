using Humanizer;
using MongoDB.Driver;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Repositories;


namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : Entity
    {
        public readonly IMongoCollection<TEntity> Collection;

        public MongoRepository(IMongoDatabase database)
        {
            var collectionName = typeof(TEntity).Name.Pluralize().ToLower();
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public IQueryable<TEntity> GetAllQuery => Collection.AsQueryable();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await Collection.Find(filter).AnyAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
