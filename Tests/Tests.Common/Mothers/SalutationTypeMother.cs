using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class SalutationTypeMother
    {
        public static SalutationType Mr()
        {
            return new SalutationType { Id = 1, Description = "Mr" };
        }

        public static SalutationType Ms()
        {
            return new SalutationType { Id = 2, Description = "Ms" };
        }
    }
}