using ProductRegistry.Domain.Core.Interfaces;
using ProductRegistry.Domain.Core.Notications;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Interfaces.Services;
using ProductRegistry.Domain.Models;
using ProductRegistry.Domain.Resources;
using ProductRegistry.Domain.Services.Base;
using ProductRegistry.Domain.Validations.Resources;

namespace ProductRegistry.Domain.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IHandler<DomainNotification> notifications,
                             IProductRepository productRepository,
                             ICategoryRepository categoryRepository) : base(notifications)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var getProduct = await GetOwnerIdProductId(entity);

            if (Notifications.HasError())
                return entity;

            if (await NotExistCategory(entity.CategoryId, entity.OwnerId))
            {
                Notifications.Handle(DomainNotification.ModelValidation(ValidationMessages.GetMessage(nameof(DomainResources.CategoryNotFound)),
                                     string.Format(DomainResources.CategoryNotFound, entity.CategoryId)));
                return entity;
            }

            getProduct.Update(entity.Title, entity.Description, entity.Price, entity.CategoryId);

            await _productRepository.UpdateAsync(getProduct);

            return entity;
        }

        private async Task<Product> GetOwnerIdProductId(Product entity)
        {
            var getProductOwner = await _productRepository.GetByOwnerIdProjectId(entity.OwnerId, entity.Id);

            if (getProductOwner == null)
            {
                Notifications.Handle(DomainNotification.ModelValidation(ValidationMessages.GetMessage(nameof(DomainResources.ProductNotFound)),
                                    string.Format(DomainResources.ProductNotFound, entity.Id)));
                return entity;
            }

            return getProductOwner;
        }

        private async Task<bool> NotExistCategory(Guid categoryId, Guid ownerId)
         => Guid.Empty.Equals(categoryId) ? false : !await _categoryRepository.ExistsAsync(categoryId, ownerId);
    }
}