using AutoMapper;
using MediatR;
using ProductRegistry.Application.Events.Categories;
using ProductRegistry.Application.UseCases.Base;
using ProductRegistry.Application.UseCases.Categories.Request;
using ProductRegistry.Application.UseCases.Categories.Response;
using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryUseCase : UseCaseBaseRequestToDomain<CreateCategoryRequest, Category, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMediator _mediator;
        public CreateCategoryUseCase(IHandler<DomainNotification> notifications,
                                     IMediator mediator,
                                     ICategoryService baseService,
                                     IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
            _categoryService = baseService;
            _mediator = mediator;
        }

        public override async Task<CategoryResponse> HandleSafeMode(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Category>(request);
            await _categoryService.InsertAsync(entity);
           
            if (Notifications.HasError())
                return Mapper.Map<CategoryResponse>(entity);

            await _mediator.Publish(CategoryEventRequest.SetCategory(entity));

            return Mapper.Map<CategoryResponse>(entity);
        }
    }
}
