using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class EducationDetailRepository : Repository
    {
        public EducationDetailRepository(ISession session) : base(session) {}
        public EducationDetailRepository() : base(SessionFactory.OpenSession()) {}

        public EducationDetail Save(EducationDetail educationDetail)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEducationDetail = SaveOrUpdate(educationDetail, txn);
                txn.Commit();
                return savedEducationDetail;
            }
        }

        public EducationDetail Update(EducationDetail educationDetail)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEducationDetail = SaveOrUpdate(educationDetail, txn);
                txn.Commit();
                return savedEducationDetail;
            }
        }

        public EducationDetail Load(int id)
        {
            return session.Get<EducationDetail>(id);
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var educationDetail = Load(id);
                if (educationDetail != null)
                {
                    session.Delete(educationDetail);
                }
                txn.Commit();
            }
        }

        public IList<EducationDetail> LoadAll(Constituent constituent)
        {
            var criteria = session.CreateCriteria<EducationDetail>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituent.Id));
            return criteria.List<EducationDetail>();
        }

    }
}