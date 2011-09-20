using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{

    [CollectionDataContract(Namespace = "")]
    public class CommitteesData : List<CommitteeData> { }

    [DataContract(Namespace = "")]
    public class CommitteeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public ConstituentData Constituent { get; set; }

        [DataMember]
        public PositionTypeData Type { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

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