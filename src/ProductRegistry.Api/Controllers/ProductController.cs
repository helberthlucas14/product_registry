using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductRegistry.Api.Controllers.Base;
using ProductRegistry.Application.UseCases.Products.Request;
using ProductRegistry.Application.UseCases.Products.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions;

namespace ProductRegistry.Api.Controllers
{
    public class ProductController : MainController
    {
        private readonly IMediator _mediator;

        public ProductController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductResponse>> PostAsync([FromBody] CreateProductRequest request)
        {
            var result = await _mediator.Send(request);
            return ResponsePost("Post", "Product", result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProjectRequest request)
        {
            await _mediator.Send(request.SetId(id));
            return ResponsePutPatch();
        }
    }
}
