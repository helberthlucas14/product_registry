using FluentValidation;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Validations.Extensions;

namespace ProductRegistry.Application.UseCases.Products.Validations
{
    public class RegisterUpdateValidation : ProductUpdateValidation
    {
        public RegisterUpdateValidation(IProductRepository productRepository,
                                       ICategoryRepository categoryRepository)
                              : base(productRepository, categoryRepository)
        {
            ValidateOwnerId();
            ValidateCategoryId();
            ValidateTitle();
            ValidateDescription();
            ValidatePrice();
        }
    }
    public class ProductUpdateValidation : AbstractValidator<UpdateProjectRequest>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductUpdateValidation(IProductRepository productRepository,
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

        private Task<bool> ValidateTitleKeyAsync(UpdateProjectRequest product)
            => Task.FromResult(_productRepository.GetAllQuery(product.OwnerId).Any(p => p.Title.Equals(product.Title) && p.Id == product.Id));

        private async Task<bool> ValidateCategoryIdAsync(UpdateProjectRequest product)
        {
            if (Guid.Empty.Equals(product.CategoryId))
                return await _categoryRepository.GetByIdAsync(product.CategoryId.Value, product.OwnerId) != null;

            return false;
        }

    }
}
