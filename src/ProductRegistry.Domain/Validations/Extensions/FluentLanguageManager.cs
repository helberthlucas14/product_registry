using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Validators;
using System.Globalization;

namespace ProductRegistry.Domain.Validations.Extensions
{
    public class FluentLanguageManager : LanguageManager
    {
        public FluentLanguageManager()
        {
            AddTranslation("pt-BR", nameof(NotNullValidator), "'{PropertyName}' é obrigatório.");
            AddTranslation("pt-BR", "OnlyDigitsValidator", "'{PropertyName}' só aceita dígitos.");
            AddTranslation("pt-BR", "GuidValidator", "'{PropertyName}' não pode estar vazio.");
            AddTranslation("pt-BR", "ExactLengthValidator2", "'{PropertyName}' deve ter o comprimento exato de {MaxLength} caracteres.");
            AddTranslation("pt-BR", "LengthValidator2", "'{PropertyName}' deve ter entre {MinLength} e {MaxLength} caracteres.");
        }

        private static string GetMessage(string key, string propertyName, object? parameters = null, CultureInfo? culture = null)
        {
            var result = ValidatorOptions.Global.LanguageManager.GetString(key, culture);
            var messageBuilder = ValidatorOptions.Global.MessageFormatterFactory();
            messageBuilder.AppendArgument("PropertyName", propertyName);
            if (parameters != null)
            {
                parameters.GetType().GetProperties().ToList().ForEach(property =>
                {
                    messageBuilder.AppendArgument(property.Name, property.GetValue(parameters));
                });
            }
            result = messageBuilder.BuildMessage(result);

            return result;
        }

        public static string GetEnumValidator(string propertyName)
        {
            return GetMessage(nameof(EnumValidator), propertyName);
        }

        public static string GetEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(EqualValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetGreaterThanValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(GreaterThanValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetGreaterThanOrEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(GreaterThanOrEqualValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetLengthValidator(string propertyName, object minLength, object maxLength, object totalLength)
        {
            return GetMessage(nameof(LengthValidator), propertyName, new { MinLength = minLength, MaxLength = maxLength, TotalLength = totalLength });
        }

        public static string GetLengthValidator2(string propertyName, object minLength, object maxLength)
        {
            return GetMessage("LengthValidator2", propertyName, new { MinLength = minLength, MaxLength = maxLength });
        }

        public static string GetMinimumLengthValidator(string propertyName, object minLength, object totalLength)
        {
            return GetMessage(nameof(MinimumLengthValidator), propertyName, new { MinLength = minLength, TotalLength = totalLength });
        }

        public static string GetMinimumLengthValidator2(string propertyName, object minLength)
        {
            return GetMessage("MinimumLengthValidator2", propertyName, new { MinLength = minLength });
        }

        public static string GetMaximumLengthValidator(string propertyName, object maxLength, object totalLength)
        {
            return GetMessage(nameof(MaximumLengthValidator), propertyName, new { MinLength = maxLength, MaxLength = maxLength, TotalLength = totalLength });
        }

        public static string GetMaximumLengthValidator2(string propertyName, object maxLength)
        {
            return GetMessage("MaximumLengthValidator2", propertyName, new { MinLength = maxLength, MaxLength = maxLength });
        }

        public static string GetLessThanValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(LessThanValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetLessThanOrEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(LessThanOrEqualValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetNotEmptyValidator(string propertyName)
        {
            return GetMessage(nameof(NotEmptyValidator), propertyName);
        }

        public static string GetNotEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage(nameof(NotEqualValidator), propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetNotNullValidator(string propertyName)
        {
            return GetMessage(nameof(NotNullValidator), propertyName);
        }

        public static string GetNullValidator(string propertyName)
        {
            return GetMessage(nameof(NullValidator), propertyName);
        }

        public static string GetPredicateValidator(string propertyName)
        {
            return GetMessage(nameof(PredicateValidator), propertyName);
        }

        public static string GetAsyncPredicateValidator(string propertyName)
        {
            return GetMessage(nameof(AsyncPredicateValidator), propertyName);
        }

        public static string GetRegularExpressionValidator(string propertyName)
        {
            return GetMessage(nameof(RegularExpressionValidator), propertyName);
        }

        public static string GetExactLengthValidator(string propertyName, object maxLength, object totalLength)
        {
            return GetMessage(nameof(ExactLengthValidator), propertyName, new { MaxLength = maxLength, TotalLength = totalLength });
        }

        public static string GetExactLengthValidator2(string propertyName, object maxLength)
        {
            return GetMessage("ExactLengthValidator2", propertyName, new { MaxLength = maxLength });
        }

        public static string GetExclusiveBetweenValidator(string propertyName, object from, object to)
        {
            return GetMessage(nameof(ExclusiveBetweenValidator), propertyName, new { From = from, To = to });
        }

        public static string GetInclusiveBetweenValidator(string propertyName, object from, object to)
        {
            return GetMessage(nameof(InclusiveBetweenValidator), propertyName, new { From = from, To = to });
        }

        public static string GetEmptyValidator(string propertyName)
        {
            return GetMessage(nameof(EmptyValidator), propertyName);
        }

        public static string GetCreditCardValidator(string propertyName)
        {
            return GetMessage(nameof(CreditCardValidator), propertyName);
        }

        public static string GetScalePrecisionValidator(string propertyName, object ExpectedPrecision, object ExpectedScale)
        {
            return GetMessage(nameof(ScalePrecisionValidator), propertyName, new { expectedPrecision = ExpectedPrecision, expectedScale = ExpectedScale });
        }

        public static string GetGuidValidator(string propertyName)
        {
            return GetMessage("GuidValidator", propertyName);
        }

        public static string GetFieldNotInformedValidator(string propertyName, string fieldName)
        {
            return GetMessage("FieldNotInformedValidator", propertyName, new { FieldName = fieldName });
        }

        public static string GetFieldNotInUseValidator(string propertyName)
        {
            return GetMessage("FieldNotInUseValidator", propertyName);
        }

        public static string GetFieldInUseValidator(string propertyName)
        {
            return GetMessage("FieldInUseValidator", propertyName);
        }

        public static string GetInvalidImageValidator(string propertyName)
        {
            return GetMessage("InvalidImageValidator", propertyName);
        }

        public static string GetForeignKeyValidator(string propertyName)
        {
            return GetMessage("ForeignKeyValidator", propertyName);
        }

        public static string GetUniqueValidator(string propertyName)
        {
            return GetMessage("UniqueValidator", propertyName);
        }

        public static string GetNotAllowedValidator()
        {
            return GetMessage("NotAllowedValidator", "");
        }

        public static string GetOnlyDigitsValidator(string propertyName)
        {
            return GetMessage("OnlyDigitsValidator", propertyName);
        }

        public static string GetMutualExcludeRegistrationServiceValidator()
        {
            return GetMessage("MutualExcludeRegistrationServiceValidator", "");
        }

        public static string GetAtLeastOneRegistrationServiceValidator()
        {
            return GetMessage("AtLeastOneRegistrationServiceValidator", "");
        }

        public static string GetExecutionRequestWithoutCallbackValidation()
        {
            return GetMessage("ExecutionRequestWithoutCallbackValidation", "");
        }
    }
}
