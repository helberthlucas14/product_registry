using ProductRegistry.Domain.Interfaces.Services.Base;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseServiceEntity<Category>
    {
        Task<Category> InsertAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
    }
}
