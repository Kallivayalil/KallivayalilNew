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
    }
}