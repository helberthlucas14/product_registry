using Humanizer;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Repositories.Base;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Models;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Middlewares;


namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : Entity
    {
        public readonly IMongoCollection<TEntity> Collection;
        private IOwnerService _tenantService;

        public MongoRepository(IMongoDatabase database, IOwnerService tenantService)
        {
            var collectionName = typeof(TEntity).Name.Pluralize().ToLower();
            Collection = database.GetCollection<TEntity>(collectionName);
            _tenantService = tenantService;
        }

        public IQueryable<TEntity> GetAllQuery =>
                  Collection.Find(GetOwnerFilter(_tenantService.OwnerId)).ToEnumerable().AsQueryable();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id) & GetOwnerFilter(_tenantService.OwnerId);
            return await Collection.Find(filter).AnyAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id) & GetOwnerFilter(_tenantService.OwnerId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            var result = await Collection.ReplaceOneAsync(filter, entity);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public FilterDefinition<TEntity> GetOwnerFilter(Guid ownerId) =>
             Builders<TEntity>.Filter.Eq(nameof(Entity.OwnerId), ownerId);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
