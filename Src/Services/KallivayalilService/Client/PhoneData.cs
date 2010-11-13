using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class PhonesData : List<PhoneData> { }

    [DataContract(Namespace = "")]
    public class PhoneData 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Number{ get; set; } 
        
        [DataMember]
        public LinkData Address { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }
        
        [DataMember]
        public int Type{ get; set; }

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