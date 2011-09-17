using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class CommitteeRepository : Repository
    {
        public CommitteeRepository(ISession session) : base(session) {}
        public CommitteeRepository() : base(SessionFactory.OpenSession()) {}


        public Committee Save(Committee committee)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedCommittee = SaveOrUpdate(committee, txn);
                txn.Commit();
                return savedCommittee;
            }
        }

        public Committee Update(Committee committee)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedCommittee = SaveOrUpdate(committee, txn);
                txn.Commit();
                return savedCommittee;
            }
        }

        public Committee Load(int id)
        {
            return session.Get<Committee>(id);
        }

       
        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var committee = Load(id);
                if (committee != null)
                {
                    session.Delete(committee);
                }
                txn.Commit();
            }
        }

    }
}