using ProductRegistry.Application.AutoMapper;

namespace ProductRegistry.Api.Configurations.Api
{
    public static class AutoMapperSetup
    {
        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(RequestToDomainMappingProfile));

            AutoMapperConfig.RegisterMappings();

            return services;
        }
    }
}
