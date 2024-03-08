using MongoDB.Bson.Serialization;
using ProductRegistry.Domain.Models;

namespace ProductRegistry.Infrastructure.Data.Context.Configurations.Mongo
{
    public class CategoryMongoConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Category>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(p => p.Title).SetIsRequired(true);
                cm.MapMember(p => p.Description).SetIsRequired(true);
            });
        }
    }
}
