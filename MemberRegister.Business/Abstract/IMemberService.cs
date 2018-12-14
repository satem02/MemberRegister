using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.Business.Abstract {
    public interface IMemberService {
        void Add (Member member);
        Member Get (Expression<Func<Member, bool>> condition);
        Member GetById (string id);
        IEnumerable<Member> GetList (Expression<Func<Member, bool>> condition = null);
        void Delete (Member member);
        void DeleteById (string id);
        void Update (Member member);
    }
}