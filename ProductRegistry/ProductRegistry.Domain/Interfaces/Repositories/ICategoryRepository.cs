using ProductRegistry.Domain.Core.Models;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IMongoRepository<Category>
    {

    }
}
