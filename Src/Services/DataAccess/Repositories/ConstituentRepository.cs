using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Helper;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentRepository : Repository, IConstituentRepository
    {
        private readonly NHibernateCriteriaHelper nHibernateCriteriaHelper;

        public ConstituentRepository(ISession session) : base(session)
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
        }

        public ConstituentRepository() : this(SessionFactory.OpenSession())
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
        }

        public Constituent Save(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public virtual Constituent Update(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public virtual void Delete(int constituentId)
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

        public virtual Constituent Load(int constituentId)
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
            var nameCriteria = criteria.CreateCriteria("Name");
            criteria = CreateCriterion(firstName, lastName, preferedName, matchAllCriteria, nameCriteria);
            return criteria.List<Constituent>().ToList();
        }

        private ICriteria CreateCriterion(string firstName, string lastName, string preferedName, bool matchAllCriteria, ICriteria nameCriteria)
        {
            var firstNameCriterion = nHibernateCriteriaHelper.GetCriterion("FirstName", firstName);
            var lastNameCriterion = nHibernateCriteriaHelper.GetCriterion("LastName", lastName);
            var preferredNameCriterion = nHibernateCriteriaHelper.GetCriterion("PreferedName", preferedName);
            return nHibernateCriteriaHelper.ConstructCriteria(matchAllCriteria, nameCriteria, firstNameCriterion, lastNameCriterion,preferredNameCriterion);
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

        public List<Constituent> ConstituentsForApproval()
        {
            var criteria = session.CreateCriteria<Constituent>();
            criteria.Add(Restrictions.Eq("IsRegistered", 'A'));
            return criteria.List<Constituent>().ToList();
        }

        public void CascadeDelete(int constituentId)
        {
            using (var txn = session.BeginTransaction())
            {
                var constituent = session.Load<Constituent>(constituentId);

                if (constituent != null)
                {
                    var email = session.CreateCriteria<Email>().Add(Restrictions.Eq("Constituent", constituent)).Add(Restrictions.Eq("IsPrimary", true)).UniqueResult<Email>();

                    session.CreateSQLQuery("delete from logins where email = " + email.Id).ExecuteUpdate();
                    session.CreateSQLQuery("delete from emails where ConstituentId = " + constituentId).ExecuteUpdate();
                    session.CreateSQLQuery("delete from phones where ConstituentId = " + constituentId).ExecuteUpdate();
                    session.CreateSQLQuery("delete from addresses where ConstituentId = " + constituentId).ExecuteUpdate();

                    session.Delete(constituent);
                }
                txn.Commit();
            }
        }
    }
}