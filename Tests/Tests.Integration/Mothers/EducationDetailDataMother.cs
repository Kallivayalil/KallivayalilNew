using System;
using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class EducationDetailDataMother
    {
        public static EducationDetailData School(Constituent constituent)
        {
            return new EducationDetailData
                       {
                           Type = new EducationTypeData {Id = 1, Description = "School"},
                           Qualification = "12th grade",
                           InstituteName = "SHY",
                           InstituteLocation = "Yercaud",
                           YearOfGraduation = DateTime.Now.ToShortDateString(),
                           Constituent = new LinkData {Id = constituent.Id},
                       };
        }

        public static EducationDetailData School(EducationDetail educationDetail)
        {
            return new EducationDetailData
                       {
                           Type = new EducationTypeData {Description = "School", Id = 1},
                           Qualification = educationDetail.Qualification,
                           InstituteLocation = educationDetail.InstituteLocation,
                           InstituteName = educationDetail.InstituteName,
                           YearOfGraduation = educationDetail.YearOfGraduation,
                           Constituent = new LinkData {Id = educationDetail.Constituent.Id},
                       };
        }
    }
}