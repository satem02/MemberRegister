using System;
using MemberRegister.Core.DataAccess.EntityFramework;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.DataAccess.Concrete.EntityFramework {
    public class efMemberDal : efRepositoryBase<Member, NorthwindContext>, IMemberDal {

    }
}