using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Constituent> SearchEducationDetailBy(string instituteName, string instituteLocation, string qualification, string yearofGraduation)
        {
            var criteria = session.CreateCriteria<EducationDetail>();
            criteria.Add(Restrictions.InsensitiveLike("InstituteName", GetPropertyValue(instituteName))
                || Restrictions.InsensitiveLike("InstituteLocation", GetPropertyValue(instituteLocation))
                || Restrictions.InsensitiveLike("YearOfGraduation", GetPropertyValue(yearofGraduation))
                || Restrictions.InsensitiveLike("Qualification", GetPropertyValue(qualification)));
            var occupations = criteria.List<EducationDetail>();

            return occupations.Select(occupation => occupation.Constituent).ToList();

        }

        private string GetPropertyValue(string propertyValue)
        {
            return string.IsNullOrEmpty(propertyValue) ? propertyValue : string.Format("%{0}%", propertyValue);
        }

    }
}