using ProductRegistry.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Domain.Interfaces.Services.Base
{
    public interface IBaseServiceEntity<TEntity> : IBaseService where TEntity : Entity
    {
        Task<TEntity> RegisterAsync(TEntity entity);
        IQueryable<TEntity> GetAllQuery(Guid ownerId);
        Task<TEntity> GetByIdAsync(Guid id, Guid ownerId);
        Task<bool> ExistsAsync(Guid id, Guid ownerId);
    }
}
