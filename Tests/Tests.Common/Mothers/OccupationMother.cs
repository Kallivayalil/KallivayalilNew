using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class OccupationMother
    {
        public static Occupation Doctor(Constituent constituent)
        {
            return new Occupation { Constituent = constituent, OccupationName = "Doctor",Description = "Senior Doc", Type = OccupationTypeMother.Primary() };
        }

        public static Occupation Doctor(Constituent constituent, Address address)
        {
            var doctor = Doctor(constituent);
            doctor.Address = address;

            return doctor;
        }
    }
}