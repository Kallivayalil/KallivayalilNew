using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class SearchResultData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public int BranchName { get; set; }

        [DataMember]
        public string HouseName { get; set; }

        [DataMember]
        public DateTime BornOn { get; set; }

        [DataMember]
        public DateTime? DiedOn { get; set; }

        [DataMember]
        public bool HasExpired { get; set; }

        [DataMember]
        public int MaritialStatus { get; set; }

        [DataMember]
        public bool IsRegistered { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public ConstituentNameData Name { get; set; }

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