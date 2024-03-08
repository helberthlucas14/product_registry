using Microsoft.Extensions.DependencyInjection;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Infrastructure.Data.Repositories;

namespace ProductRegistry.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            return services;
        }
    }
}
