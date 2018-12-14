using System;
using MongoDB.Bson;

namespace MemberRegister.Core.DataAccess.MongoDB {
    public class Utilities {
        public static string GetObjectId => ObjectId.GenerateNewId ().ToString ();
    }
}