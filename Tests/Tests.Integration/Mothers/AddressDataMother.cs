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
                           Type = 1,
                           Constituent = new LinkData {Id = constituent.Id},
                       };
        }

        public static AddressData London(Constituent constituent)
        {
            return new AddressData
                       {
                           Line1 = "190 Bermondsey Street",
                           City = "London",
                           State = "London",
                           PostCode = "SE1 3TQ",
                           Country = "UK",
                           Type = 1,
                           Constituent = new LinkData { Id = constituent.Id },
                       };
        }
    }
}