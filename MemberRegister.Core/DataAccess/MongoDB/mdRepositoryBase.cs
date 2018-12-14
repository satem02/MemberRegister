using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using MemberRegister.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MemberRegister.Core.DataAccess.MongoDB {
    public class mdRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, EntityBase, new () {
            IMongoCollection<TEntity> _collection;
            string _tableName = typeof (TEntity).Name;

            public mdRepositoryBase (MongoContext context) {
                _collection = context.SessionFactory.GetCollection<TEntity> (_tableName);
            }
            public void Add (TEntity entity) {
                if (string.IsNullOrEmpty (entity.Id))
                    entity.Id = Utilities.GetObjectId;
                _collection.InsertOne (entity);
            }

            public void Delete (TEntity entity) {
                _collection.DeleteOne (x => x.Id == entity.Id);
            }

            public TEntity Get (Expression<Func<TEntity, bool>> condition) {
                return _collection.Find (condition).SingleOrDefault ();
            }

            public IEnumerable<TEntity> GetList (Expression<Func<TEntity, bool>> condition = null) {
                return condition == null ?
                    _collection.Find (x => !string.IsNullOrEmpty (x.Id)).ToEnumerable () :
                    _collection.Find (condition).ToEnumerable ();
            }
            public void Update (TEntity entity) {
                _collection.ReplaceOne (x => x.Id == entity.Id, entity);
            }
        }
}