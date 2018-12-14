using System;
using MemberRegister.Core.DataAccess.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemberRegister.Entities.Concrete {
    public class Member : EntityBase {

        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DisplayName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}