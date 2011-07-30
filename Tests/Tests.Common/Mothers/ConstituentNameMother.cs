using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class ConstituentNameMother
    {
        public static ConstituentName JamesFranklin()
        {
            return new ConstituentName
                       {
                           FirstName = "James",
                           LastName = "Franklin",
                           MiddleName = "H",
                           Salutation = SalutationTypeMother.Mr(),
                           PreferedName = "James",
                       };
        }

        public static ConstituentName JessicaAlba()
        {
            return new ConstituentName
                       {
                           FirstName = "Jessica",
                           LastName = "Alba",
                           MiddleName = "H",
                           Salutation = SalutationTypeMother.Ms(),
                           PreferedName = "Jess",
                       };
        }
    }
}