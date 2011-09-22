using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class OccupationRepository : Repository,ISubEntityRepository<Occupation>
    {
        public OccupationRepository(ISession session) : base(session) {}
        public OccupationRepository() : base(SessionFactory.OpenSession()) {}

        public Occupation Save(Occupation occupation)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedOccupation = SaveOrUpdate(occupation, txn);
                txn.Commit();
                return savedOccupation;
            }
        }

        public Occupation Update(Occupation occupation)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedOccupation = SaveOrUpdate(occupation, txn);
                txn.Commit();
                return savedOccupation;
            }
        }

        public Occupation Load(int id)
        {
            return session.Get<Occupation>(id);
        }

        public IList<Occupation> LoadAll(int constituentId)
        {
            var criteria = session.CreateCriteria<Occupation>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            return criteria.List<Occupation>();
        }

        public Occupation GetPrimary(int constituentId)
        {
            var criteria = session.CreateCriteria<Occupation>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            criteria.Add(Restrictions.Eq("IsPrimary", true));
            return criteria.UniqueResult<Occupation>();
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var occupation = Load(id);
                if (occupation != null)
                {
                    session.Delete(occupation);
                }
                txn.Commit();
            }
        }

        public IList<Occupation> LoadAll(Constituent constituent)
        {
            var criteria = session.CreateCriteria<Occupation>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituent.Id));
            return criteria.List<Occupation>();
        }

        public IList<Occupation> LoadAll(Address address)
        {
            var criteria = session.CreateCriteria<Occupation>();
            criteria.Add(Restrictions.Eq("Address.Id", address.Id));
            return criteria.List<Occupation>();
        }

        public List<Constituent> SearchOccupationBy(string occupationName, string description, bool matchAllCriteria)
        {
            var criteria = session.CreateCriteria<Occupation>();
            criteria.Add(AbstractCriterion(occupationName, description,matchAllCriteria));
            var occupations = criteria.List<Occupation>();

            return occupations.Select(occupation => occupation.Constituent).ToList();
        }

        private AbstractCriterion AbstractCriterion(string occupationName, string description, bool matchAllCriteria)
        {
            return matchAllCriteria ?
                   (Restrictions.InsensitiveLike("OccupationName", GetPropertyValue(occupationName)) 
                   && Restrictions.InsensitiveLike("Description", GetPropertyValue(description)))
                   :
                   (Restrictions.InsensitiveLike("OccupationName", GetPropertyValue(occupationName)) 
                   || Restrictions.InsensitiveLike("Description", GetPropertyValue(description)));
        }

        private string GetPropertyValue(string propertyValue)
        {
            return string.IsNullOrEmpty(propertyValue) ? propertyValue : string.Format("%{0}%", propertyValue);
        }
    }
}