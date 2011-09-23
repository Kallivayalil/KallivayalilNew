using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.DataAccess.Helper;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class EducationDetailRepository : Repository
    {
        private readonly NHibernateCriteriaHelper nHibernateCriteriaHelper;

        public EducationDetailRepository(ISession session) : base(session)
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
            
        }
        public EducationDetailRepository() : base(SessionFactory.OpenSession())
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
            
        }

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

        public List<Constituent> SearchEducationDetailBy(string instituteName, string instituteLocation, string qualification, string yearofGraduation, bool matchAllCriteria)
        {
            var criteria = session.CreateCriteria<EducationDetail>();
            criteria = CreateCriterion(instituteName, instituteLocation, yearofGraduation, qualification,matchAllCriteria,criteria);
            var occupations = criteria.List<EducationDetail>();

            return occupations.Select(occupation => occupation.Constituent).ToList();

        }

        private ICriteria CreateCriterion(string instituteName, string instituteLocation, string yearofGraduation, string qualification, bool matchAllCriteria, ICriteria criteria)
        {
            var instituteNameCriteria = nHibernateCriteriaHelper.GetCriterion("InstituteName", instituteName);
            var instituteLocationCriteria = nHibernateCriteriaHelper.GetCriterion("InstituteLocation", instituteLocation);
            var yearOfGraduationCriteria = nHibernateCriteriaHelper.GetCriterion("YearOfGraduation", yearofGraduation);
            var qualificationCriteria = nHibernateCriteriaHelper.GetCriterion("Qualification", qualification);
            return nHibernateCriteriaHelper.ConstructCriteria(matchAllCriteria, criteria, instituteNameCriteria, instituteLocationCriteria, yearOfGraduationCriteria, qualificationCriteria);
        }

       

    }
}