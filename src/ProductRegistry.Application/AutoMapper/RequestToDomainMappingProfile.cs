using AutoMapper;
using ProductRegistry.Application.Events.Base;
using ProductRegistry.Application.Events.Categories;
using ProductRegistry.Application.Events.Products;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.Categories.Request;
using ProductRegistry.Application.UseCases.Products.Handlers;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Application.AutoMapper
{
    public class RequestToDomainMappingProfile : Profile
    {
        public RequestToDomainMappingProfile()
        {
            CreateMap<ApiErrorLogRequest, ApiErrorLog>();

            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProjectRequest, Product>();

            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();

            CreateMap<ProductEventRequest, NotificationRequest>();
            CreateMap<CategoryEventRequest, NotificationRequest>();
            
        }

    }
}
