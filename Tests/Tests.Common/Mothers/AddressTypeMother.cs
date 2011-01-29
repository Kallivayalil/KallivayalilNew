using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class AddressTypeMother
    {
        public static AddressType Home()
        {
            return new AddressType {Id = 1, Description = "Home"};
        }

        public static AddressType Office()
        {
            return new AddressType {Id = 2, Description = "Office"};
        }
    }
}