using MongoDB.Bson.Serialization;
using ProductRegistry.Domain.Core.Models;

namespace ProductRegistry.Infrastructure.Data.Context.Configurations.Mongo
{
    public class EntityMongoConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(e => e.Id).SetIsRequired(true);
                cm.MapMember(e => e.OwnerId).SetIsRequired(true);
                cm.MapMember(e => e.CreateAt).SetIsRequired(true);
                cm.MapMember(e => e.ModifyAt).SetIsRequired(false);
                cm.MapMember(e => e.DeleteAt).SetIsRequired(false);
                cm.MapMember(e => e.IsDeleted).SetIsRequired(false);
            });
        }
    }
}
