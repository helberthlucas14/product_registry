using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Infrastructure.Data.Context.Configurations.Mongo
{
    public class EntityMongoConfiguration<TEntity> where TEntity : Entity
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<TEntity>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(e => e.Id).SetIdGenerator(new GuidGenerator());

                cm.MapMember(e => e.OwnerId).SetIsRequired(true);
                
                cm.MapMember(e => e.CreateAt).SetIsRequired(true);
                
                cm.MapMember(e => e.ModifyAt).SetIsRequired(false);
                
                cm.MapMember(e => e.DeleteAt).SetIsRequired(false);
                
                cm.MapMember(e => e.IsDeleted).SetIsRequired(false)
                                             .SetDefaultValue(false);
            });
        }
    }
}
