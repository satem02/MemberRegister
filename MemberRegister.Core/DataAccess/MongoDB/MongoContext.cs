using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MemberRegister.Core.DataAccess.MongoDB {
    public abstract class MongoContext : IDisposable {
        private static IMongoDatabase _IMongoDatabase;
        public virtual IMongoDatabase SessionFactory {
            get { return _IMongoDatabase ?? (_IMongoDatabase = InitializeFactory); }
        }

        protected abstract IMongoDatabase InitializeFactory { get; }

        public IMongoDatabase GetDatabase () => _IMongoDatabase;

        public void Dispose () {
            GC.SuppressFinalize (this);
        }
    }
}