using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class OccupationsData : List<OccupationData> {}

    [DataContract(Namespace = "")]
    public class OccupationData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string OccupationName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public LinkData Address { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public OccupationTypeData Type { get; set; }

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