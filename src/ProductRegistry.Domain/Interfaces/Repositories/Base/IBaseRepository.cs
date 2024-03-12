using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(Guid id, Guid ownerId);

        IQueryable<TEntity> GetAllQuery(Guid ownerId);

        Task<bool> ExistsAsync(Guid id, Guid ownerId);

        public Task<bool> UpdateAsync(TEntity entity);
    }
}
