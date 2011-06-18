using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ReferenceDataRepository : Repository
    {
        public ReferenceDataRepository(ISession session) : base(session) {}
        public ReferenceDataRepository() : base(SessionFactory.OpenSession()) {}


        public new  IList<T> LoadAll<T>() where T : IEntity
        {
            return base.LoadAll<T>();
        }


    }
}