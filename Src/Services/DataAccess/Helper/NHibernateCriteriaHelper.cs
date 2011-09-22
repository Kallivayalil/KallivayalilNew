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
                foreach (AbstractCriterion t in criterias)
                {
                    if (t != null)
                        criteria.Add(Restrictions.Conjunction().Add(t));
                }
            }
            else
            {
                foreach (AbstractCriterion t in criterias)
                {
                    if (t != null)
                        criteria.Add(Restrictions.Disjunction().Add(t));
                }

            }
            return criteria;
        }
    }
}
