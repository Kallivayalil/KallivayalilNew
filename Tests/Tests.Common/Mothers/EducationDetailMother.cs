using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class EducationDetailMother
    {
        public static EducationDetail School(Constituent constituent)
        {
            return new EducationDetail
                       {
                           Constituent = constituent,
                           Qualification = "10th Grade",
                           InstituteName = "SHY",
                           InstituteLocation = "Yercaud",
                           YearOfGraduation = DateTime.Now.Date.ToShortDateString(),
                           Type = EducationDetailTypeMother.School()
                       };
        }
        public static EducationDetail College(Constituent constituent)
        {
            return new EducationDetail
                       {
                           Constituent = constituent,
                           Qualification = "Cse",
                           InstituteName = "PSG",
                           InstituteLocation = "CBE",
                           YearOfGraduation = "1995",
                           Type = EducationDetailTypeMother.University()
                       };
        }
    }
}