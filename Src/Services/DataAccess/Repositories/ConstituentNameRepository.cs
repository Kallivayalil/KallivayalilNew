using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentNameRepository : Repository
    {
        public ConstituentNameRepository(ISession session) : base(session) {}
        public ConstituentNameRepository() : base(SessionFactory.OpenSession()) {}

        public ConstituentName Save(ConstituentName constituentName)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituentName = SaveOrUpdate(constituentName, txn);
                txn.Commit();
                return savedConstituentName;
            }
        }


        public ConstituentName Update(ConstituentName constituentName)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituentName = SaveOrUpdate(constituentName, txn);
                txn.Commit();
                return savedConstituentName;
            }
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var constituentName = session.Load<ConstituentName>(id);
                if (constituentName != null)
                {
                    session.Delete(constituentName);
                }
                txn.Commit();
            }
        }

        public ConstituentName Load(int id)
        {
            return Load<ConstituentName>(id);
        }
    }
}