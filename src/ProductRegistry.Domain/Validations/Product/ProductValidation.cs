using FluentValidation;
using ProductRegistry.Domain.Validations.Base;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Validations.Extensions;


namespace ProductRegistry.Domain.Validations.Product
{
    public class ProductValidation : BaseValidation<Models.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductValidation(IProductRepository productRepository,
                                 ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
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
            RuleFor(x => x.CategoryId)
                .IsGuid()
                .MustAsync(async (entity, resource, collection) =>
                {
                    return !await ValidateCategoryIdAsync(entity);
                })
                .WithMessage("Category not found.");
        }
        protected void ValidateTitle()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .MaximumLength(50)
                .NotEmpty()
                .MustAsync(async (entity, resource, colletion) =>
                 {
                     return !await ValidateTitleKeyAsync(entity);
                 })
                .WithMessage("Title must by unique.");
        }

        protected void ValidateDescription()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .MaximumLength(200)
                .NotEmpty();
        }

        protected void ValidatePrice()
        {
            RuleFor(x => x.Price)
                .GreaterThan(0);
        }

        private Task<bool> ValidateTitleKeyAsync(Models.Product product)
            => Task.FromResult(_productRepository.GetAllQuery.Any(p => !string.IsNullOrEmpty(p.Title) && p.Title.Equals(product.Title)));

        private async Task<bool> ValidateCategoryIdAsync(Models.Product product)
               => await _categoryRepository.GetByIdAsync(product.CategoryId) == null;

    }
}
