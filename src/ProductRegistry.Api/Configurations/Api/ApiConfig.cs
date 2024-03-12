﻿using FluentValidation.AspNetCore;
using ProductRegistry.Api.Configurations.Swagger;
using ProductRegistry.Api.Filter;
using ProductRegistry.Domain.Validations.ApiErrorLog;
using ProductRegistry.Domain.Validations.Extensions;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Providers;
using System.Text.Json.Serialization;

namespace ProductRegistry.Api.Configurations.Api
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureStatupApi(this IServiceCollection services, IConfiguration configuration)
        {

            services.LoadConfiguration(configuration);
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidationFilter));
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApiErrorLogValidation>());

            FluentConfiguration.ConfigureFluent();

            services.AddSwaggerDocumentation(configuration);

            services.AddControllersWithViews(options =>
            {
                options.Conventions.Add(new PluralizeControllerModelConvention());
            });

            return services;
        }
        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase($"/{AppProvider.Name}");

            app.UseSwaggerDocumentation(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("All");

            app.UseHsts();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
