using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{

    [CollectionDataContract(Namespace = "")]
    public class UploadDatas : List<UploadData> { }

    [DataContract(Namespace = "")]
    public class UploadData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public ConstituentData Constituent { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

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