using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public abstract class Repository : IRepository, IDisposable
    {
        protected static readonly ISessionFactory SessionFactory = ConfigurationFactory.SessionFactory;
        protected readonly ISession session;


        protected Repository(ISession session)
        {
            this.session = session;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (session.IsOpen)
                session.Close();
        }

        #endregion

        #region IRepository Members

        public virtual T SaveOrUpdateAndFlush<T>(T entity, ITransaction transaction = null) where T : IEntity
        {
            object savedEntity = session.SaveOrUpdateCopy(entity);
            session.Flush();
            return (T) savedEntity;
        }

        public virtual T SaveOrUpdate<T>(T entity, ITransaction transaction = null) where T : IEntity
        {
            object savedCopy = session.SaveOrUpdateCopy(entity);
            return (T) savedCopy;
        }

        public T Load<T>(int entityId) where T : class
        {
            return session.Load<T>(entityId);
        }

        public T Get<T>(int entityId) where T : IEntity
        {
            return session.Get<T>(entityId);
        }

        public IList<T> LoadAll<T>() where T : IEntity
        {
            return session.CreateCriteria(typeof (T)).List<T>();
        }

        public bool Exists(IEntity entity)
        {
            if (entity == null)
                return false;
            if (entity.Id <= 0)
                return false;
            var savedEntityCount =
                session.CreateCriteria(entity.GetType()).Add(Restrictions.Eq("Id", entity.Id)).SetProjection(Projections.Count("Id")).UniqueResult
                    <Int32>();
            return savedEntityCount > 0;
        }

        public bool Exists(Type entityType, int entityId)
        {
            if (entityId <= 0)
                return false;

            object savedEntity = session.Get(entityType, entityId);
            if (savedEntity != null)
            {
                session.Evict(savedEntity);
                return true;
            }
            return false;
        }

        public bool Exists<T>(int entityId) where T : IEntity
        {
            return Exists(typeof (T), entityId);
        }

        public IEntity Load(IEntity entity)
        {
            return session.CreateCriteria(entity.GetType()).Add(Restrictions.Eq("Id", entity.Id)).UniqueResult<IEntity>();
        }

        public void Flush()
        {
            session.Flush();
        }

        public void Evict(IEntity entity)
        {
            session.Evict(entity);
        }

        public virtual IEntity Delete(IEntity entity)
        {
            session.Delete(entity);
            session.Flush();
            return entity;
        }

        #endregion
    }
}