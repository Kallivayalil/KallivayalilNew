using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class AddressDataMother
    {
        public static AddressData SanFrancisco(Constituent constituent)
        {
            return new AddressData
                       {
                           Line1 = "315 Montgomery Street",
                           City = "San Francisco",
                           State = "California",
                           PostCode = "ABCD",
                           Country = "USA",
                           Type = new AddressTypeData {Id = 1, Description = "Home"},
                           Constituent = new LinkData {Id = constituent.Id},
                       };
        }

        public static AddressData London(Constituent constituent)
        {
            var addressData = London();
            addressData.Constituent = new LinkData {Id = constituent.Id};
            return addressData;
        }

        public static AddressData London()
        {
            return new AddressData
                       {
                           Line1 = "190 Bermondsey Street",
                           City = "London",
                           State = "London",
                           PostCode = "SE1 3TQ",
                           Country = "UK",
                           IsPrimary = true,
                           Type = new AddressTypeData {Id = 1, Description = "Home"},
                       };
        }
    }
}