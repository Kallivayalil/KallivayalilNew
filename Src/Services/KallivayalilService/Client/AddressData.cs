using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class AddressesData : List<AddressData> {}

    [DataContract(Namespace = "")]
    public class AddressData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string City { get; set; }  
        
        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }

        [DataMember]
        public AddressTypeData Type { get; set; }

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