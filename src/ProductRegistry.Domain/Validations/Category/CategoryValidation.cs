using FluentValidation;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Validations.Base;
using ProductRegistry.Domain.Validations.Extensions;

namespace ProductRegistry.Domain.Validations.Category
{
    public class CategoryValidation : BaseValidation<Models.Category>
    {
        private readonly IMongoRepository<Models.Category> _categoryRepository;

        public CategoryValidation(IMongoRepository<Models.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        protected void ValidateOwnerId()
        {
            RuleFor(x => x.OwnerId)
                .NotNull()
                .IsGuid();
        }

        protected void ValidateCategoryId()
        {
            RuleFor(x => x.OwnerId)
                .IsGuid();
        }
        protected void ValidateTitle()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .MaximumLength(50)
                .NotEmpty()
                .MustAsync(async (entity, resource, colletion) =>
                {
                    return !await ValidateTitleKey(entity);
                })
                .WithMessage("Title must by unique.");
            ;
        }

        protected void ValidateDescription()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .MaximumLength(200);
        }

        private async Task<bool> ValidateTitleKey(Models.Category product)
                  => _categoryRepository.GetAllQuery.Any(p => !string.IsNullOrEmpty(p.Title) && p.Title.Equals(product.Title));
    }
}
