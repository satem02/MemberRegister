using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Core.DataAccess.MongoDB;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.DataAccess.Concrete.MongoDB {
    public class mdMemberDal : mdRepositoryBase<Member>, IMemberDal {
        private MongoContext _mongoContext;
        public mdMemberDal (MongoContext mongoContext) : base (mongoContext) {
            _mongoContext = mongoContext;
        }
    }
}