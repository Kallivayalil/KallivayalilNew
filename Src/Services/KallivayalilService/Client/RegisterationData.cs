using System;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class RegisterationData
    {
        [DataMember]
        public ConstituentData Constituent { get; set; }

        [DataMember]
        public AddressData Address { get; set; }

        [DataMember]
        public string Email { get; set; } 
        
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public PhoneData Phone { get; set; }

        
    }
}