using ProductRegistry.Api.Configurations.Swagger;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Providers;

namespace ProductRegistry.Api.Configurations.Api
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureStatupApi(this IServiceCollection services, IConfiguration configuration)
        {

            services.LoadConfiguration(configuration);

            return services;
        }
        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase($"/{AppProvider.Name}");

            app.UseSwaggerDocumentation(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
