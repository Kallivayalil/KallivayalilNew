using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface IRepository
    {
        T SaveOrUpdateAndFlush<T>(T entity, ITransaction transaction = null) where T : IEntity;
        T SaveOrUpdate<T>(T entity, ITransaction transaction = null) where T : IEntity;
        T Load<T>(int entityId) where T : IEntity;
        T Get<T>(int entityId) where T : IEntity;
        IList<T> LoadAll<T>() where T : IEntity;
        bool Exists(IEntity entity);
        bool Exists<T>(int entityId) where T : IEntity;
        bool Exists(Type entityType, int entityId);
        IEntity Load(IEntity entity);
        void Flush();
        void Evict(IEntity entity);
        IEntity Delete(IEntity entity);
    }
}