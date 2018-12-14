using System;
using MemberRegister.Core.DataAccess.MongoDB;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.DataAccess.Concrete.MongoDB {
    public class mdUserDal : mdRepositoryBase<User>, IUserDal {
        private MongoContext _mongoContext;
        public mdUserDal (MongoContext mongoContext) : base (mongoContext) {
            _mongoContext = mongoContext;
        }
    }
}