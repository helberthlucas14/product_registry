﻿using MongoDB.Bson.Serialization;
using ProductRegistry.Domain.Models;


namespace ProductRegistry.Infrastructure.Data.Context.Configurations.Mongo
{
    public class ProductMongoConfiguration : EntityMongoConfiguration<Product>
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);

                cm.MapMember(p => p.Title).SetIsRequired(true);

                cm.MapMember(p => p.Description).SetIsRequired(true);

                cm.MapMember(p => p.Price).SetIsRequired(true);

                cm.MapMember(p => p.Category).SetIgnoreIfNull(true)
                                             .SetDefaultValue(null);

                cm.MapMember(p => p.CategoryId).SetIsRequired(true)
                                              .SetDefaultValue(null);
            });
        }
    }
}
