using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MemberRegister.Core.Entities;

namespace MemberRegister.Core.DataAccess {
    public interface IEntityRepository<T> where T : class, IEntity, new () {
        IEnumerable<T> GetList (Expression<Func<T, bool>> condition = null);
        T Get (Expression<Func<T, bool>> condition);
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);
    }
}