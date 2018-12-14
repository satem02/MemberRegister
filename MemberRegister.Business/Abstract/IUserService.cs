using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.Business.Abstract {
    public interface IUserService {
        void Add (User user);
        IEnumerable<User> GetList (Expression<Func<User, bool>> condition = null);

    }
}