using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Validation;

namespace ProductRegistry.Domain.Validations.Product
{
    public class RegisterProductValidation : ProductValidation, IRegisterValidation<Models.Product>
    {
        public RegisterProductValidation(IProductRepository ProductRepository, 
            ICategoryRepository categoryRepository) : base(ProductRepository, categoryRepository)
        {
            ValidateOwnerId();
            ValidateCategoryId();
            ValidateTitle();
            ValidateDescription();
            ValidatePrice();
        }
    }
}
