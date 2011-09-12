using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class TreeData
    {
        [DataMember(Name = "$orn")]
        public string orientation { get; set; }

        [DataMember]
        public string type { get; set; } 
        
        [DataMember]
        public string spouse { get; set; }
    }
}