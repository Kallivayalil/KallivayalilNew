using System;
using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class CommitteeDataMother
    {
        public static CommitteeData President(Constituent constituent)
        {
            return new CommitteeData { Constituent = new LinkData(){Id = constituent.Id}, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Type = new PositionTypeData(){Id = 1} };
        }

        public static CommitteeData Secretary(Constituent constituent)
        {
            return new CommitteeData { Constituent = new LinkData() { Id = constituent.Id }, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Type = new PositionTypeData() { Id = 1 } };
        }


     
    }
}