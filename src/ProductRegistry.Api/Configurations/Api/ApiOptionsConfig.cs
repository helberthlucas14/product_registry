using ProductRegistry.Infrastructure.CrossCutting.Commons.Providers;
using MongoDB.Driver;

namespace ProductRegistry.Api.Configurations.Api
{
    public static class ApiOptionsConfig
    {
        public static IServiceCollection LoadConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var appConfig = configuration.Get<AppConfig>();
            services.AddSingleton(typeof(DbSettingsProvider), appConfig.DbSettings);
            services.AddSingleton(typeof(AwsSettingsProvider), appConfig.AWSSettings);

            return services;
        }

        public static IServiceCollection MongoConfiguration(this IServiceCollection services, DbSettingsProvider dbSettingsProvider)
        {
            if (dbSettingsProvider == null)
                throw new ArgumentNullException(nameof(dbSettingsProvider));

            services.AddScoped<IMongoClient>(s => new MongoClient(dbSettingsProvider.ConnectionString));
            return services;
        }
    }

    internal class AppConfig
    {
        public DbSettingsProvider DbSettings { get; set; } = new DbSettingsProvider();
        public AwsSettingsProvider AWSSettings { get; set; } = new AwsSettingsProvider();
    }
}
