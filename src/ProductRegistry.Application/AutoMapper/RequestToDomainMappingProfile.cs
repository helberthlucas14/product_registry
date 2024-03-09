using AutoMapper;
using ProductRegistry.Application.UseCases.ApiErrorLog.Request;
using ProductRegistry.Application.UseCases.Categories.Request;
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
            CreateMap<CreateCategoryRequest, Category>();
        }

    }
}
