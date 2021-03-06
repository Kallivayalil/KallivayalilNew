using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class ConstituentData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public BranchTypeData BranchName { get; set; }

        [DataMember]
        public string HouseName { get; set; }

        [DataMember]
        public DateTime BornOn { get; set; }

        [DataMember]
        public DateTime? DiedOn { get; set; }
        
        [DataMember]
        public char IsRegistered { get; set; }

        [DataMember]
        public bool HasExpired { get; set; }

        [DataMember]
        public int MaritialStatus { get; set; }

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
    }

    [CollectionDataContract(Namespace = "")]
    public class ConstituentsData : List<ConstituentData> {}
}