using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductRegistry.Application.UseCases.ApiErrorLog.Handlers;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Application.UseCases.Products.Handlers;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Validation;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Services;
using ProductRegistry.Domain.Validations.ApiErrorLog;
using ProductRegistry.Domain.Validations.Product;
using ProductRegistry.Infrastructure.Data.Repositories;

namespace ProductRegistry.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterInfraService(services);
            RegisterApplicationServices(services);
            RegisterDomainServices(services);
            return services;
        }


        public static IServiceCollection RegisterInfraService(IServiceCollection services)
        {
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IApiErrorLogService, ApiErrorLogService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRegisterValidation<ApiErrorLog>, RegisterApiErrorLogValidation>();
            services.AddScoped<IRegisterValidation<Product>, RegisterProductValidation>();

            return services;
        }


        public static IServiceCollection RegisterApplicationServices(IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<GetErrorsRequest, GetErrorsResponse>, GetApiErrorLogUseCase>();
            services.AddScoped<IRequestHandler<ApiErrorLogRequest, ApiErrorLogResponse>, CreateApiErrorLogUseCase>();


            services.AddScoped<IRequestHandler<CreateProductRequest, ProductResponse>, CreateProductUseCase>();

            return services;
        }


    }
}
