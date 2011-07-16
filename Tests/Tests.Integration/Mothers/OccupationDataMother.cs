using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class OccupationDataMother
    {
        public static OccupationData Doctor(Constituent constituent, Address address)
        {
            return new OccupationData()
                       {
                           Type = new OccupationTypeData(){Description = "Primary",Id = 1},
                           OccupationName = "Doctor",
                           Description = "Senior Doctor",
                           Constituent = new LinkData {Id = constituent.Id},
                           Address = new LinkData {Id = address.Id}
                       };
        }

        public static OccupationData Doctor(Occupation occupation)
        {
            return new OccupationData()
                       {
                           Type = new OccupationTypeData() { Description = "Mobile", Id = 1 },
                           OccupationName = occupation.OccupationName,
                           Description = occupation.Description,
                           Constituent = new LinkData { Id = occupation.Constituent.Id },
                           Address = new LinkData { Id = occupation.Address.Id }
                       };
        }
    }
}