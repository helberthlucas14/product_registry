using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Interfaces.Validation;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Resources;
using ProductRegistry.Domain.Services.Base;
using ProductRegistry.Domain.Validations.Resources;

namespace ProductRegistry.Domain.Services
{
    public class CategoryService : BaseServiceValidation<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository baseRepository,
                              IHandler<DomainNotification> notifications,
                              IRegisterValidation<Category> registerValidation)
            : base(baseRepository, notifications, registerValidation)
        {
            _categoryRepository = baseRepository;
        }

        public async Task<Category> InsertAsync(Category entity)
        {
            if (!await base.VerifyRegister(entity))
                return entity;

            if (await _categoryRepository.GetByTitleAsync(entity.Title) != null)
            {
                Notifications.Handle(DomainNotification.ModelValidation(ValidationMessages.GetMessage(nameof(DomainResources.CategoryNotFound)),
                          string.Format(DomainResources.CategoryExists, entity.Title)));
                return entity;
            }

            await base.RegisterAsync(entity);

            return entity;
        }
    }
}