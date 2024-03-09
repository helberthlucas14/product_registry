using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Domain.Validations.Extensions
{
    public static class FluentExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> SetMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> options, string stringName)
            => options.WithMessage(ValidatorOptions.Global.LanguageManager.GetString(stringName));

        public static IRuleBuilderOptions<T, Guid> IsGuid<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder
                .NotEqual(Guid.Empty).SetMessage("GuidValidator");
        }
    }
}
