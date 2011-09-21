using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class CommitteeMother
    {
        public static Committee President(Constituent constituent)
        {
            return new Committee {Constituent = constituent, StartYear = "2004",EndYear = "2005", Type = PositionTypeMother.President()};
        }

        public static Committee Secretary(Constituent constituent)
        {
            return new Committee { Constituent = constituent, StartYear = "2004", EndYear = "2005", Type = PositionTypeMother.Secretary() };
        }
    }
}