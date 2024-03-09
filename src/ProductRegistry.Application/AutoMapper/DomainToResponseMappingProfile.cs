using AutoMapper;
using ProductRegistry.Application.UseCases.ApiErrorLog.Response;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Application.AutoMapper
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<ApiErrorLog, ApiErrorLogResponse>();

            CreateMap<Product, ProductResponse>();
        }
    }
}
