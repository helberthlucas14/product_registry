using AutoMapper;
using MediatR;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Application.UseCases.Products.Handlers
{
    public class CreateProductUseCase : UseCaseBaseRequestToDomain<CreateProductRequest, Product, ProductResponse>
    {
        public CreateProductUseCase(IHandler<DomainNotification> notifications,
            IMediator mediator,
            IBaseServiceEntity<Product> baseService,
            IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
        }

        public override Task<ProductResponse> HandleSafeMode(CreateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
