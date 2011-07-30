using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class EducationDetailsData : List<EducationDetailData> {}

    [DataContract(Namespace = "")]
    public class EducationDetailData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public string InstituteName { get; set; }

        [DataMember]
        public string InstituteLocation { get; set; }

        [DataMember]
        public string YearOfGraduation { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }

        [DataMember]
        public EducationTypeData Type { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }
    }
}