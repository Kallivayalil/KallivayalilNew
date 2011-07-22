using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class EducationDetail : Entity
    {
        public virtual EducationType Type { get; set; }
        public virtual string Qualification { get; set; }
        public virtual string InstituteName { get; set; }
        public virtual string InstituteLocation { get; set; }
        public virtual string YearOfGraduation { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}