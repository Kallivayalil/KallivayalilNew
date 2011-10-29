using System;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class LoginData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public EmailData Email { get; set; }

        [DataMember]
        public string Password { get; set; }
        
        [DataMember]
        public bool IsAdmin { get; set; }

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