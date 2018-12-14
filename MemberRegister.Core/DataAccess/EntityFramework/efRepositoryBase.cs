using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MemberRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberRegister.Core.DataAccess.EntityFramework {
    public class efRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new ()
    where TContext : DbContext, new () {
        public void Add (TEntity entity) {
            using (var context = new TContext ()) {
                var activeEntity = context.Entry (entity);
                activeEntity.State = EntityState.Added;
                context.SaveChanges ();
            }
        }

        public void Delete (TEntity entity) {
            using (var context = new TContext ()) {
                var activeEntity = context.Entry (entity);
                activeEntity.State = EntityState.Deleted;
                context.SaveChanges ();
            }
        }

        public TEntity Get (Expression<Func<TEntity, bool>> condition) {
            using (var context = new TContext ()) {
                return context.Set<TEntity> ().SingleOrDefault (condition);
            }
        }

        public IEnumerable<TEntity> GetList (Expression<Func<TEntity, bool>> condition = null) {
            using (var context = new TContext ()) {
                return condition == null ?
                    context.Set<TEntity> ().AsEnumerable () :
                    context.Set<TEntity> ().Where (condition).AsEnumerable ();
            }
        }

        public void Update (TEntity entity) {
            using (var context = new TContext ()) {
                var activeEntity = context.Entry (entity);
                activeEntity.State = EntityState.Modified;
                context.SaveChanges ();
            }
        }
    }
}