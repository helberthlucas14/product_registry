using FluentValidation;
using ProductRegistry.Domain.Validations.Base;


namespace ProductRegistry.Domain.Validations.ApiErrorLog
{
    public class ApiErrorLogValidation : BaseValidation<Models.ApiErrorLog>
    {
        protected void ValidateRootCause()
        {
            RuleFor(x => x.RootCause)
                .NotEmpty();
        }

        protected void ValidateMessage()
        {
            RuleFor(x => x.Message)
                .NotEmpty();
        }

        protected void ValidateType()
        {
            RuleFor(x => x.Type)
                .NotEmpty();
        }
    }
}
