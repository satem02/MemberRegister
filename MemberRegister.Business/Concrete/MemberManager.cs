using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Business.Abstract;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.Entities.Concrete;

namespace MemberRegister.Business.Concrete {
    public class MemberManager : IMemberService {
        IMemberDal _memberDal;
        public MemberManager (IMemberDal memberDal) {
            _memberDal = memberDal;
        }

        public void Add (Member member) {
            _memberDal.Add (member);
        }

        public void Delete (Member member) {
            _memberDal.Delete (member);
        }

        public void DeleteById (string id) {
            var deletedEntity = GetById (id);
            Delete (deletedEntity);
        }

        public Member Get (Expression<Func<Member, bool>> condition) {
            return _memberDal.Get (condition);
        }

        public Member GetById (string id) {
            return _memberDal.Get (x => x.Id == id);
        }
        public IEnumerable<Member> GetList (Expression<Func<Member, bool>> condition = null) {
            return _memberDal.GetList (condition);
        }

        public void Update (Member member) {
            _memberDal.Update (member);
        }
    }
}