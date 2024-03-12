using Humanizer;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Repositories.Base;
using ProductRegistry.Domain.Models;


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

        public IQueryable<TEntity> GetAllQuery(Guid ownerId)
        {
            return Collection.Find(GetOwnerFilter(ownerId)).ToEnumerable().AsQueryable();

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> ExistsAsync(Guid id, Guid ownerId)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id) & GetOwnerFilter(ownerId);
            return await Collection.Find(filter).AnyAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, Guid ownerId)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id) & GetOwnerFilter(ownerId); ;
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            var result = await Collection.ReplaceOneAsync(filter, entity);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public FilterDefinition<TEntity> GetOwnerFilter(Guid ownerId)
        {
            return Builders<TEntity>.Filter.Eq("OwnerId", ownerId);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
