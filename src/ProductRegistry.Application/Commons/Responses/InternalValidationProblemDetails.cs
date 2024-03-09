using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProductRegistry.Application.Commons.Responses
{
    public class InternalValidationProblemDetails
    {
        public string Title { get; set; }
        public IEnumerable<ErrrorDetail> Errors { get; set; }

        public InternalValidationProblemDetails(ModelStateDictionary modelState)
        {
            Title = "One or more validation errors occurred.";
            Errors = modelState.Select(x => new ErrrorDetail { Key = x.Key, Value = x.Value.Errors?.Select(x => x.ErrorMessage).FirstOrDefault() ?? string.Empty });
        }

        public InternalValidationProblemDetails(IDictionary<string, string[]> errors)
        {
            Title = "One or more validation errors occurred.";
            Errors = errors.Select(x => new ErrrorDetail { Key = x.Key, Value = x.Value.FirstOrDefault() ?? string.Empty });
        }

        public class ErrrorDetail
        {
            public string Key { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
        }

        public void SetNotifications(IHandler<DomainNotification> notifications)
        {
            foreach (var error in Errors)
                notifications.Handle(DomainNotification.ModelValidation(error.Key, error.Value));
        }
    }
}
