using System;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class ContactUsData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public  string Name { get; set; }

        [DataMember]
        public  string Email { get; set; } 
        
        [DataMember]
        public  string Comments { get; set; }

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