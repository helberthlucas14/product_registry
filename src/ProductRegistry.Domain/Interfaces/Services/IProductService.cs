using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService
    {
        Task<Product> UpdateAsync(Product entity);
    }
}
