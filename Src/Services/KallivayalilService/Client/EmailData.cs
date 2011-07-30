using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class EmailsData : List<EmailData> {}

    [DataContract(Namespace = "")]
    public class EmailData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }

        [DataMember]
        public EmailTypeData Type { get; set; }

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