using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class ConstituentNameMother
    {
        public static ConstituentName Franklin()
        {
            return new ConstituentName
            {
                FirstName = "A.J.",
                LastName = "Franklin",
                MiddleName = "H",
                Salutation = SalutationTypeMother.Mr(),
                PreferedName = "Franky",
            };
        }

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

        public static ConstituentName AgnesAlba()
        {
            return new ConstituentName
                       {
                           FirstName = "Agnes",
                           LastName = "Alba",
                           MiddleName = "H",
                           Salutation = SalutationTypeMother.Ms(),
                           PreferedName = "Jess",
                       };
        }
    }
}