using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Validations.Extensions;

namespace ProductRegistry.Domain.Validations.Base
{
    public abstract class BaseValidation<TEntity> : AbstractValidator<TEntity> where TEntity : Entity
    {
        protected const int DefaultVarcharLenght = 2000;

        protected void ValidateId() => RuleFor(x => x.Id).NotNull().IsGuid();

        public virtual async Task<ValidationResult> IsValidAsync(TEntity entity, TEntity? oldEntity = null)
        {
            var context = new ValidationContext<TEntity>(entity);
            context.RootContextData.Add("oldEntity", oldEntity);
            return await ValidateAsync(context);
        }

        public virtual ValidationResult IsValid(TEntity entity, TEntity? oldEntity = null)
        {
            var context = new ValidationContext<TEntity>(entity);
            context.RootContextData.Add("oldEntity", oldEntity);
            return Validate(context);
        }

        protected TEntity OldEntity(PropertyValidatorContext context) => OldEntity(context.ParentContext);

        protected TEntity OldEntity(IValidationContext context) => (TEntity)context.RootContextData["oldEntity"];
    }
}
