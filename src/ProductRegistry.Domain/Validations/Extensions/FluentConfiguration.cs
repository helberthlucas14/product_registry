﻿using FluentValidation;
using System.Globalization;


namespace ProductRegistry.Domain.Validations.Extensions
{
    public static class FluentConfiguration
    {
        public static void ConfigureFluent()
        {
            ValidatorOptions.Global.LanguageManager = new FluentLanguageManager
            {
                Culture = new CultureInfo("pt-BR")
            };
        }
    }
}
