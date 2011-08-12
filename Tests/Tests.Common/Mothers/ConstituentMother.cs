using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public class ConstituentMother
    {
        public static Constituent ConstituentWithName(ConstituentName constituentName)
        {
            var constituent = new Constituent {Gender = "F", BornOn = DateTime.Today, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituent.Name = constituentName;
            return constituent;
        }
    }
}