using AutoMapper;
using MediatR;
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
        public CreateCategoryUseCase(IHandler<DomainNotification> notifications,
                                     IMediator mediator,
                                     ICategoryService baseService,
                                     IMapper mapper) : base(notifications, mediator, baseService, mapper)
        {
            _categoryService = baseService;
        }

        public override async Task<CategoryResponse> HandleSafeMode(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Category>(request);
            await _categoryService.InsertAsync(entity);
            return Mapper.Map<CategoryResponse>(entity);
        }
    }
}
