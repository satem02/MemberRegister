using System;
using MemberRegister.Core.DataAccess.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MemberRegister.DataAccess.Concrete.MongoDB {
    public class MongoHelper : MongoContext {
        private Settings _setting;

        public MongoHelper (IOptions<Settings> options) {
            _setting = new Settings ();
            _setting.ConnectionString = options.Value.ConnectionString;
            _setting.Database = options.Value.Database;
        }

        protected override IMongoDatabase InitializeFactory {
            get {
                var client = new MongoClient (_setting.ConnectionString);
                var _db = client.GetDatabase (_setting.Database);
                return _db;
            }
        }
    }
}