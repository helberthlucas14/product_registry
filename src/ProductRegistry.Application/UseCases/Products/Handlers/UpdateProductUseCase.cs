using AutoMapper;
using MediatR;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Services;


namespace ProductRegistry.Application.UseCases.Products.Handlers
{
    public class UpdateProductUseCase : UseCaseBase<UpdateProjectRequest, ProductResponse>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(IHandler<DomainNotification> notifications,
            IMediator mediator,
            IMapper mapper,
            IProductService productService) : base(notifications, mediator)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public override async Task<ProductResponse> HandleSafeMode(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);

            await _productService.UpdateAsync(entity);

            return _mapper.Map<ProductResponse>(entity);
        }
    }
}
