using System;
using Kallivayalil.Common;
using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentRepository : Repository
    {
        protected static readonly ISessionFactory SessionFactory = ConfigurationFactory.SessionFactory;

        public ConstituentRepository(ISession session) : base(session) {}

        public ConstituentRepository() : base(SessionFactory.OpenSession()){}

        public Constituent Save(Constituent constituent)
        {
            using (var txn =session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent,txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public Constituent Update(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public void Delete(int constituentId)
        {
            using (var txn = session.BeginTransaction())
            {
                var constituent = session.Load<Constituent>(constituentId);
                if(constituent != null)
                {
                    session.Delete(constituent);
                }
                txn.Commit();
            }
        }

        public Constituent Load(int constituentId)
        {
               return session.Load<Constituent>(constituentId);
        }
    }
}