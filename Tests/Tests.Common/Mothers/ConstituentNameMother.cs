using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class ConstituentNameMother {
        public static ConstituentName JamesFranklin(Constituent constituent)
        {
            return new ConstituentName
                       {
                           FirstName = "James",
                           LastName = "Franklin",
                           MiddleName = "H",
                           Salutation = 1,
                           PreferedName = "James",
                           Constituent = constituent,
                       };
        }
    }
}