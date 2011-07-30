using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class AsociationMother
    {
        public static Association JamesFranklinAndJessicaAlba(Constituent constituent, Constituent associatedConstituent)
        {
            return new Association()
                       {
                           Type = AssociationTypeMother.Spouse(),
                           Constituent = constituent,
                           AssociatedConstituent = associatedConstituent,
                       };
        }

        public static Association JamesFranklinAndParent(Constituent constituent)
        {
            return new Association()
                       {
                           Type = AssociationTypeMother.Parent(),
                           Constituent = constituent,
                           AssociatedConstituentName = "Franklin",
                       };
        }

    }
}