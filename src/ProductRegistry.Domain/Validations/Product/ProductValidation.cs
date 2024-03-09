using FluentValidation;
using ProductRegistry.Domain.Validations.Base;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Validations.Extensions;


namespace ProductRegistry.Domain.Validations.Product
{
    public class ProductValidation : BaseValidation<Models.Product>
    {
        private readonly IMongoRepository<Models.Product> _productRepository;

        public ProductValidation(IMongoRepository<Models.Product> productRepository)
        {
            _productRepository = productRepository;
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
                     return !await ValidateTitleKeyAsync(entity);
                 })
                .WithMessage("Title must by unique.");
            ;
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
                .GreaterThan(-1)
                .NotEmpty();
        }

        private async Task<bool> ValidateTitleKeyAsync(Models.Product product)
            => _productRepository.GetAllQuery.Any(p => !string.IsNullOrEmpty(p.Title) && p.Title.Equals(product.Title));

    }
}
