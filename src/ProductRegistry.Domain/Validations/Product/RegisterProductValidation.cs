using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Validation;

namespace ProductRegistry.Domain.Validations.Product
{
    public class RegisterProductValidation : ProductValidation, IRegisterValidation<Models.Product>
    {
        public RegisterProductValidation(IMongoRepository<Models.Product> repository) : base(repository)
        {
            ValidateOwnerId();
            ValidateCategoryId();
            ValidateTitle();
            ValidateDescription();
            ValidatePrice();
        }
    }
}
