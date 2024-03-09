using ProductRegistry.Domain.Interfaces.Validation;

namespace ProductRegistry.Domain.Validations.ApiErrorLog
{
    public class RegisterApiErrorLogValidation : ApiErrorLogValidation, IRegisterValidation<Models.ApiErrorLog>
    {
        public RegisterApiErrorLogValidation()
        {
            ValidateRootCause();
            ValidateMessage();
            ValidateType();
        }
    }
}
