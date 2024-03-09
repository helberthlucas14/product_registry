using MongoDB.Driver;
using ProductRegistry.Domain.Interfaces.Repositories;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Infrastructure.Data.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}