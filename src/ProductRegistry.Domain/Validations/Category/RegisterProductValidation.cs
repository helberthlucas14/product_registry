using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Validation;

namespace ProductRegistry.Domain.Validations.Category
{
    public class RegisterCategoryValidation : CategoryValidation, IRegisterValidation<Models.Category>
    {
        public RegisterCategoryValidation(IMongoRepository<Models.Category> repository) : base(repository)
        {
            ValidateOwnerId();
            ValidateCategoryId();
            ValidateTitle();
            ValidateDescription();
        }
    }
}
