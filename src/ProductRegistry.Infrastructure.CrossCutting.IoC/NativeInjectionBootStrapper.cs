using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductRegistry.Application.Events.Products;
using ProductRegistry.Application.UseCases.ApiErrorLog.Handlers;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Application.UseCases.Categories.Handlers;
using ProductRegistry.Application.UseCases.Categories.Request;
using ProductRegistry.Application.UseCases.Categories.Response;
using ProductRegistry.Application.UseCases.Products.Handlers;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Application.UseCases.Products.Validations;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Validation;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Services;
using ProductRegistry.Domain.Validations.ApiErrorLog;
using ProductRegistry.Domain.Validations.Category;
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
            services.AddScoped<INotificationHandler<ProductEventRequest>, ProductEventHandler>();

            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IApiErrorLogService, ApiErrorLogService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductServiceValidation, ProductServiceValidation>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSingleton<IOwnerService, OwnerService>();

            services.AddScoped<IRegisterValidation<ApiErrorLog>, RegisterApiErrorLogValidation>();
            services.AddScoped<IRegisterValidation<Product>, RegisterProductValidation>();
            services.AddScoped<IRegisterValidation<Category>, RegisterCategoryValidation>();

            services.AddScoped<IValidator<UpdateProjectRequest>, RegisterUpdateValidation>();

            return services;
        }


        public static IServiceCollection RegisterApplicationServices(IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<GetErrorsRequest, GetErrorsResponse>, GetApiErrorLogUseCase>();
            services.AddScoped<IRequestHandler<ApiErrorLogRequest, ApiErrorLogResponse>, CreateApiErrorLogUseCase>();


            services.AddScoped<IRequestHandler<CreateProductRequest, ProductResponse>, CreateProductUseCase>();
            services.AddScoped<IRequestHandler<UpdateProjectRequest, ProductResponse>, UpdateProductUseCase>();

            services.AddScoped<IRequestHandler<CreateCategoryRequest, CategoryResponse>, CreateCategoryUseCase>();
            services.AddScoped<IRequestHandler<UpdateCategoryRequest, CategoryResponse>, UpdateCategoryUseCase>();

            return services;
        }


    }
}
