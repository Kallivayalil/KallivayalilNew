using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class TreeData
    {
         [DataMember]
        public string familyMemberId; 
        
        [DataMember]
        public string spouseId;

        [DataMember(Name = "$orn")]
        public string orientation { get; set; }

        [DataMember]
        public string type { get; set; } 
        
        [DataMember]
        public string spouse { get; set; } 
        
        [DataMember]
        public string familyMemberUrl { get; set; } 
        
        [DataMember]
        public string spouseUrl { get; set; }
    }
}