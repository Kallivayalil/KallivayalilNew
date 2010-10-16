using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public class ConstituentMother
    {
        public static Constituent Constituent()
        {
            return new Constituent { Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
        }
    }
}