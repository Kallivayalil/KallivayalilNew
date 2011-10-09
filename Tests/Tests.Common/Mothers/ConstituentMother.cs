using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public class ConstituentMother
    {
        public static Constituent ConstituentWithName(ConstituentName constituentName, char registered = 'N')
        {
            var constituent = new Constituent { Gender = "F", BornOn = DateTime.Today, BranchName = BranchTypeMother.Anavalaril(), MaritialStatus = 1, IsRegistered = registered };
            constituent.Name = constituentName;
            return constituent;
        }
    }

}