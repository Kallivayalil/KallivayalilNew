using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class PhoneTypeMother
    {
        public static PhoneType Mobile()
        {
            return new PhoneType { Id = 1, Description = "Mobile" };
        }

        public static PhoneType Landline()
        {
            return new PhoneType { Id = 2, Description = "Landline" };
        }
    }
}