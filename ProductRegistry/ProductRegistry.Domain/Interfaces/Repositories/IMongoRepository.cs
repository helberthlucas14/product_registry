using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Repositories.Base;


namespace ProductRegistry.Domain.Interfaces.Repositories
{
    public interface IMongoRepository<TEntity> : IBaseRespository<TEntity> where TEntity : Entity
    {
    }
}
