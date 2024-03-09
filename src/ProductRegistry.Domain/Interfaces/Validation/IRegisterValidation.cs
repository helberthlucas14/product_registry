using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Interfaces.Validation.Base;

namespace ProductRegistry.Domain.Interfaces.Validation
{
    public interface IRegisterValidation<TEntity> : IBaseValidation<TEntity> where TEntity : Entity
    {
    }
}
