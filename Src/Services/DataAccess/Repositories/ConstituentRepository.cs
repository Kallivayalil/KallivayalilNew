using System;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentRepository : Repository
    {
        public ConstituentRepository(ISession session) : base(session)
        {
        }

        public ConstituentRepository() : this(SessionFactory.OpenSession()) {}

        public Constituent Save(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
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
                if (constituent != null)
                {
                    session.Delete(constituent);
                }
                txn.Commit();
            }
        }

        public Constituent Load(int constituentId)
        {
            return session.Get<Constituent>(constituentId);
        }


        public IList<Constituent> LoadAllConstituentsWithBirthdayToday()
        {
            var criteria = session.CreateCriteria<Constituent>();
            criteria.Add(Restrictions.Eq("BornOn", DateTime.Today));
            return criteria.List<Constituent>();

        }

        public List<Constituent> SearchByConstituentName(string firstName, string lastName, string preferedName, bool matchAllCriteria)
        {
            var criteria = session.CreateCriteria<Constituent>();
            criteria.CreateCriteria("Name")
                .Add(AbstractCriterion(firstName, lastName, preferedName,matchAllCriteria));
            return criteria.List<Constituent>().ToList();
        }

        private AbstractCriterion AbstractCriterion(string firstName, string lastName, string preferedName, bool matchAllCriteria)
        {
            return matchAllCriteria ? (Restrictions.InsensitiveLike("FirstName", GetPropertyValue(firstName))
                   && Restrictions.InsensitiveLike("LastName", GetPropertyValue(lastName))
                   && Restrictions.InsensitiveLike("PreferedName", GetPropertyValue(preferedName))) 
                   :
                   (Restrictions.InsensitiveLike("FirstName", GetPropertyValue(firstName))
                   || Restrictions.InsensitiveLike("LastName", GetPropertyValue(lastName))
                   || Restrictions.InsensitiveLike("PreferedName", GetPropertyValue(preferedName)));
        }

        public List<Constituent> SearchByConstituentBranch(string branchName)
        {
            var criteria = session.CreateCriteria<Constituent>();
            criteria.CreateCriteria("BranchName").Add(Restrictions.InsensitiveLike("Description", GetPropertyValue(branchName)));
          return criteria.List<Constituent>().ToList();
        }
        public List<Constituent> SearchByConstituentHouseName(string houseName)
        {
            var criteria = session.CreateCriteria<Constituent>();
            criteria.Add(Restrictions.InsensitiveLike("HouseName", GetPropertyValue(houseName)));
          return criteria.List<Constituent>().ToList();
        }

        private string GetPropertyValue(string propertyValue)
        {
            return string.IsNullOrEmpty(propertyValue) ? propertyValue : string.Format("%{0}%", propertyValue);
        }

    }
}