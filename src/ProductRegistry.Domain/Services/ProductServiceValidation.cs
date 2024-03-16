using MediatR;
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
    public class ProductServiceValidation : BaseServiceValidation<Product>, IProductServiceValidation
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public ProductServiceValidation(IProductRepository baseRepository,
            IHandler<DomainNotification> notifications,
            IRegisterValidation<Product> registerValidation,
            ICategoryRepository categoryRepository) :
                 base(baseRepository, notifications, registerValidation)
        {
            _categoryRepository = categoryRepository;
            _productRepository = baseRepository;
        }

        public async Task<Product> ProcessProjectAsync(Product entity)
        {
            if (!await base.VerifyRegister(entity))
                return entity;

            if (await NotExistCategory(entity.CategoryId, entity.OwnerId))
            {
                Notifications.Handle(DomainNotification.ModelValidation(ValidationMessages.GetMessage(nameof(DomainResources.CategoryNotFound)),
                                     string.Format(DomainResources.CategoryNotFound, entity.CategoryId)));
                return entity;
            }

            await base.RegisterAsync(entity);

            return entity;
        }

        private async Task<bool> NotExistCategory(Guid categoryId, Guid ownerId)
            => Guid.Empty.Equals(categoryId) ? false : !await _categoryRepository.ExistsAsync(categoryId);
    }
}