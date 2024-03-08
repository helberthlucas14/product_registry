using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductRegistry.Api.Controllers.Base;

namespace ProductRegistry.Api.Controllers
{
    public class ProductController : MainController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<ProductResponse>> PostAsync(CreateProductRequest request)
        {
            var result = await _mediator.Send(request);

            return ResponsePost("Post", "Product", result);
        }
    }
}
