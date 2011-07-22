using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class EducationDetailMother
    {
        public static EducationDetail School(Constituent constituent)
        {
            return new EducationDetail()
                       {
                           Constituent = constituent, 
                           Qualification = "10th Grade",
                           InstituteName = "SHY",
                           InstituteLocation = "Yercaud", 
                           YearOfGraduation = DateTime.Now.ToString(),
                           Type = EducationDetailTypeMother.School()
                       };
        }

        
    }
}