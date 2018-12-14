using System;
using MemberRegister.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace MemberRegister.Core.DataAccess.MongoDB {
    public interface EntityBase : IEntity {
        [BsonId]
        string Id { get; set; }
    }
}