using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class SearchResultData
    {
        [DataMember]
        public ConstituentData Constituent { get; set; }

        [DataMember]
        public PhonesData Phones { get; set; }

        [DataMember]
        public EmailsData Emails { get; set; }

        [DataMember]
        public AddressesData Addresses { get; set; }

        [DataMember]
        public OccupationsData Occupations { get; set; }

        [DataMember]
        public EducationDetailsData Educations { get; set; }
    }

    [CollectionDataContract(Namespace = "")]
    public class SearchResultsData : List<SearchResultData> { }

}