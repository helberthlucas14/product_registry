using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions
{
    public static class ModelStateExtension
    {
        public static string GetErrors(this ModelStateDictionary modelState)
            => string.Join(", ", modelState.Values.SelectMany(x => x.Errors.Select(y => y?.ErrorMessage)));
    }
}
