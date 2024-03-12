using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductRegistry.Api.Controllers.Base;
using ProductRegistry.Application.UseCases.Categories.Request;
using ProductRegistry.Application.UseCases.Categories.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;

namespace ProductRegistry.Api.Controllers
{
    public class CategoryController : MainController
    {
        private readonly IMediator _mediator;

        public CategoryController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }


        [HttpPost("")]
        public async Task<ActionResult<CategoryResponse>> PostAsync([FromBody] CreateCategoryRequest request)
        {
            var result = await _mediator.Send(request);
            return ResponsePost("Post", "Category", result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request)
        {
            await _mediator.Send(request.SetId(id));
            return ResponsePutPatch();
        }

    }
}
