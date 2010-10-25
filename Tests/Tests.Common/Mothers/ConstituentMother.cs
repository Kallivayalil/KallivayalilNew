using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public class ConstituentMother
    {
        public static Constituent ConstituentWithName()
        {
            var constituent = new Constituent {Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituent.Name = ConstituentNameMother.JamesFranklin();
            return constituent;
        }
    }
}