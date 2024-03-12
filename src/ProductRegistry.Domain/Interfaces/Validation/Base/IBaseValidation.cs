using ProductRegistry.Domain.Core.Models;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace ProductRegistry.Domain.Interfaces.Validation.Base
{
    public interface IBaseValidation<TEntity> where TEntity : Entity
    {
        Task<ValidationResult> IsValidAsync(TEntity entity, TEntity? oldEntity);

        ValidationResult IsValid(TEntity entity, TEntity? oldEntity);
    }
}
