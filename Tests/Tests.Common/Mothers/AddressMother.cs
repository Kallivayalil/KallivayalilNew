using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class AddressMother
    {
        public static Address SanFrancisco(Constituent constituent)
        {
            return new Address
                       {
                           Line1 = "315 Montgomery Street",
                           City = "San Francisco",
                           State = "California",
                           PostCode = "ABCD",
                           Country = "USA",
                           Type = AddressTypeMother.Home(),
                           Constituent = constituent,
                       };
        }

        public static Address London(Constituent constituent)
        {
            return new Address
                       {
                           Line1 = "190 Bermondsey Street",
                           City = "London",
                           State = "London",
                           PostCode = "SE1 3TQ",
                           Country = "UK",
                           Type = AddressTypeMother.Office(),
                           Constituent = constituent,
                       };
        }
    }
}