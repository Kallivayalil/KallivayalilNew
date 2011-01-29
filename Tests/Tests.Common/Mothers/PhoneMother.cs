using System;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class PhoneMother
    {
        public static Phone Mobile(Constituent constituent)
        {
            return new Phone {Constituent = constituent, Number = "9900012345", Type = new PhoneType{Id = 1,Description = "Mobile"}};
        }

        public static Phone Mobile(Constituent constituent, Address address)
        {
            var mobile = Mobile(constituent);
            mobile.Address = address;

            return mobile;
        }
    }
}