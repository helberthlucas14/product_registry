using AutoMapper;
using MediatR;
using ProductRegistry.Application.Events.Products;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Application.UseCases.Products.Handlers
{
    public class CreateProductUseCase : UseCaseBaseRequestToDomain<CreateProductRequest, Product, ProductResponse>
    {
        private readonly IProductServiceValidation _productService;
        private readonly IMediator _mediator;
        public CreateProductUseCase(IHandler<DomainNotification> notifications,
            IMediator mediator,
            IProductServiceValidation baseService,
            IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
            _productService = baseService;
            _mediator = mediator;
        }

        public override async Task<ProductResponse> HandleSafeMode(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Product>(request);
            await _productService.ProcessProjectAsync(entity);

            if (Notifications.HasError())
                return Mapper.Map<ProductResponse>(entity);

            await _mediator.Publish(ProductEventRequest.SetProduct(entity));

            return Mapper.Map<ProductResponse>(entity);
        }
    }
}
