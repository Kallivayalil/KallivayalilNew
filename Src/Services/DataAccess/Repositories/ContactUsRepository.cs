using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ContactUsRepository : Repository
    {
        public ContactUsRepository(ISession session) : base(session) {}
        public ContactUsRepository() : base(SessionFactory.OpenSession()) {}

        public ContactUs Save(ContactUs feedback)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedContactUs = SaveOrUpdate(feedback, txn);
                txn.Commit();
                return savedContactUs;
            }
        }

        public ContactUs Load(int id)
        {
            return session.Get<ContactUs>(id);
        }

        public IList<ContactUs> LoadAll()
        {
            var criteria = session.CreateCriteria<ContactUs>();
            return criteria.List<ContactUs>();
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var contactUs = Load(id);
                if (contactUs != null)
                {
                    session.Delete(contactUs);
                }
                txn.Commit();
            }
        }
        
    }
}