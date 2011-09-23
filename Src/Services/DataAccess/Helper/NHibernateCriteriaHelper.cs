using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Helper
{
    public class NHibernateCriteriaHelper
    {
        public ICriteria ConstructCriteria(bool matchAllCriteria, ICriteria criteria, params AbstractCriterion[] criterias)
        {
            if (matchAllCriteria)
            {
            var conjunction = Restrictions.Conjunction();

                foreach (var t in criterias.Where(t => t != null))
                {
                    conjunction.Add(t);
                }
                criteria.Add(conjunction);
            }
            else
            {
            var disjunction = Restrictions.Disjunction();

                foreach (var t in criterias.Where(t => t != null))
                {
                    disjunction.Add(t);
                }
                criteria.Add(disjunction);
            }
            return criteria;
        }


        public AbstractCriterion GetCriterion(string propertyName, string propertyValue)
        {
            return !string.IsNullOrEmpty(propertyValue) ? Restrictions.InsensitiveLike(propertyName, GetPropertyValue(propertyValue)) : null;
        }

        public string GetPropertyValue(string propertyValue)
        {
            return string.IsNullOrEmpty(propertyValue) ? propertyValue : string.Format("%{0}%", propertyValue);
        }
    }
}
