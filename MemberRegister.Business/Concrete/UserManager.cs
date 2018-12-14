using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Business.Abstract;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.Business.Concrete {
    public class UserManager : IUserService {
        IUserDal _userDal;
        public UserManager (IUserDal userDal) {
            _userDal = userDal;
        }
        public void Add (User user) {
            _userDal.Add (user);
        }
        public IEnumerable<User> GetList (Expression<Func<User, bool>> condition = null) {
            return _userDal.GetList (condition);
        }

    }
}