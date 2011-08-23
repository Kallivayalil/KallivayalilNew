using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class PhoneMother
    {
        public static Phone Mobile(Constituent constituent)
        {
            return new Phone {Constituent = constituent, Number = "9900012345", Type = PhoneTypeMother.Mobile()};
        }

        public static Phone Mobile()
        {
            return new Phone { Number = "9900012345", Type = PhoneTypeMother.Mobile()};
        }

        public static Phone Mobile(Constituent constituent, Address address)
        {
            var mobile = Mobile(constituent);
            mobile.Address = address;

            return mobile;
        }
    }
}