using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class OccupationTypeMother
    {
        public static OccupationType Primary()
        {
            return new OccupationType() { Id = 1, Description = "Primary" };
        } 
        
        public static OccupationType Secondary()
        {
            return new OccupationType() { Id = 1, Description = "Secondary" };
        }

    }
}