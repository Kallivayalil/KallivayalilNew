using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class AssociationRepository : Repository
    {
        public AssociationRepository(ISession session) : base(session) {}
        public AssociationRepository() : base(SessionFactory.OpenSession()) {}

        public Association Save(Association entity)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAssociation = SaveOrUpdate(entity, txn);
                txn.Commit();
                return savedAssociation;
            }
        }

        public Association Update(Association entity)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAssociation = SaveOrUpdate(entity, txn);
                txn.Commit();
                return savedAssociation;
            }
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var address = Load(id);
                if (address != null)
                {
                    session.Delete(address);
                }
                txn.Commit();
            }
        }

        public Association Load(int id)
        {
            return session.Get<Association>(id);
        }

        public IList<Association> LoadAll(int constituentId)
        {
            var criteria = session.CreateCriteria<Association>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            return criteria.List<Association>();
        }

    }
}