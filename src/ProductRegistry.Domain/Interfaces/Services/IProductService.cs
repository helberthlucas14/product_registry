using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Services
{
    public interface IProductService : IBaseServiceEntity<Product>
    {
        public Task<Product> ProcessProjectAsync(Product product);
    }
}
