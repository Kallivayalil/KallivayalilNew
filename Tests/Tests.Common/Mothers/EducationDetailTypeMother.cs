using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class EducationDetailTypeMother
    {
        public static EducationType School()
        {
            return new EducationType {Id = 1, Description = "School"};
        }

        public static EducationType University()
        {
            return new EducationType {Id = 2, Description = "University"};
        }
    }
}