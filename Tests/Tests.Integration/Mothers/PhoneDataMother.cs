using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class PhoneDataMother
    {
        public static PhoneData Mobile(Constituent constituent, Address address)
        {
            return new PhoneData
                       {
                           Type = new PhoneTypeData {Description = "Mobile", Id = 1},
                           Number = "9900012345",
                           Constituent = new LinkData {Id = constituent.Id},
                           Address = new ShortAddressData() {Id = address.Id}
                       };
        }
        
        public static PhoneData Mobile()
        {
            return new PhoneData
                       {
                           Type = new PhoneTypeData {Description = "Mobile", Id = 1},
                           Number = "9900012345",
                       };
        }

        public static PhoneData Mobile(Phone phone)
        {
            return new PhoneData
            {
                Type = new PhoneTypeData { Description = "Mobile", Id = 1 },
                Number = "9900012345",
                Constituent = new LinkData { Id = phone.Constituent.Id },
                Address = new ShortAddressData() { Id = phone.Address.Id }
            };
        }
    }
}