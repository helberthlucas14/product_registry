using ProductRegistry.Infrastructure.CrossCutting.Commons.Providers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Services;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon;

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


            services.MongoConfiguration(appConfig.DbSettings);

            services.SnsConfiguration(appConfig.AWSSettings);

            return services;
        }


        public static IServiceCollection SnsConfiguration(this IServiceCollection services, AwsSettingsProvider awsSettingsProvider)
        {
            var awsRegion = awsSettingsProvider.Region;
            var awsAccessKeyId = awsSettingsProvider.AccessKeyId;
            var awsSecretAccessKey = awsSettingsProvider.SecretAccessKey;

            var awsCredentials = new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);

            services.AddSingleton<IAmazonSimpleNotificationService>(sp =>
                new AmazonSimpleNotificationServiceClient(awsCredentials, new AmazonSimpleNotificationServiceConfig
                {
                    ServiceURL = awsSettingsProvider.SNS.Url
                }));

            services.AddSingleton<ISnsService>(sp =>
                new SnsService(awsSettingsProvider.SNS.Url, awsAccessKeyId, awsSecretAccessKey));

            return services;
        }


        public static IServiceCollection MongoConfiguration(this IServiceCollection services, DbSettingsProvider dbSettingsProvider)
        {
            if (dbSettingsProvider == null)
                throw new ArgumentNullException(nameof(dbSettingsProvider));

            services.AddScoped<IMongoDatabase>(s =>
            {
                var mongoUrl = new MongoUrl(dbSettingsProvider.ConnectionString);
                var mongoClient = new MongoClient(mongoUrl);
                var databaseName = mongoUrl.DatabaseName;
                return mongoClient.GetDatabase(databaseName);
            });

            return services;
        }
    }

    internal class AppConfig
    {
        public DbSettingsProvider DbSettings { get; set; } = new DbSettingsProvider();
        public AwsSettingsProvider AWSSettings { get; set; } = new AwsSettingsProvider();

    }
}
