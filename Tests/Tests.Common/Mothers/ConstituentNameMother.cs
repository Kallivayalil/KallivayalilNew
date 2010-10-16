using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class ConstituentNameMother {
        public static ConstituentName JamesFranklin()
        {
            return new ConstituentName
                       {
                           FirstName = "James",
                           LastName = "Franklin",
                           MiddleName = "H",
                           Salutation = 1,
                           PreferedName = "James",
                           ConstituentId = 1
                       };
        }
    }
}