using System;
using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class CommitteeDataMother
    {
        public static CommitteeData President(Constituent constituent)
        {
            return new CommitteeData { Constituent = new ConstituentData(){Id = constituent.Id}, StartYear = "2004", EndYear = "2008", Type = new PositionTypeData(){Id = 1} };
        }

        public static CommitteeData Secretary(Constituent constituent)
        {
            return new CommitteeData { Constituent = new ConstituentData() { Id = constituent.Id }, StartYear = "2004", EndYear = "2008", Type = new PositionTypeData() { Id = 1 } };
        }


     
    }
}