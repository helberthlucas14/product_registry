using MongoDB.Driver;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Repositories;


namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepository(IMongoDatabase database)
        {
            var collection = $"{nameof(TEntity)}s";
            _collection = database.GetCollection<TEntity>(collection);
        }

        public IQueryable<TEntity> GetAllQuery => _collection.AsQueryable();

        public IQueryable<TEntity> GetAllQueryNoTracking => _collection.AsQueryable();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
