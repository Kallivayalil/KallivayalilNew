using Kallivayalil.Client;
using Kallivayalil.Domain;
using Tests.Common.Mothers;

namespace Tests.Integration.Mothers
{
    public static class AssociationDataMother
    {
        public static AssociationData JamesAndJessica(Constituent constituent, Constituent associatedConstituent)
        {
            return new AssociationData()
                       {
                           Type = new AssociationTypeData(){Description = "Spouse",Id=1},
                           AssociatedConstituent = new ConstituentData {Id= associatedConstituent.Id},
                           Constituent = new ConstituentData { Id = constituent.Id },
                       };
        }

    }
}