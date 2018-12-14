using System;
using MemberRegister.Core.DataAccess.MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace MemberRegister.Entities.Concrete {
    public class User : EntityBase {
        [BsonId]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}