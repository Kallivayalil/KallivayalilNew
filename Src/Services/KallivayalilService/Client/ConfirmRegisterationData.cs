using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class ConfirmRegisterationData
    {
        [DataMember]
        public int ConstituentToRegister { get; set; }

        [DataMember]
        public int Constituent { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public bool UpdateAndRegister { get; set; } 
        
    }
}