using System;
using MemberRegister.Core.DataAccess;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.DataAccess.Abstract {
    public interface IMemberDal : IEntityRepository<Member> { }
}