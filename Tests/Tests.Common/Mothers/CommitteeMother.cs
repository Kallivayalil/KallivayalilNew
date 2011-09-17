using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class CommitteeMother
    {
        public static Committee President(Constituent constituent)
        {
            return new Committee {Constituent = constituent, StartDate = DateTime.Now,EndDate = DateTime.Now.AddMonths(2), Type = PositionTypeMother.President()};
        }

        public static Committee Secretary(Constituent constituent)
        {
            return new Committee { Constituent = constituent, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Type = PositionTypeMother.Secretary() };
        }
    }
}