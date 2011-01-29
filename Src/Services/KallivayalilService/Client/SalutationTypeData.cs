using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class SalutationTypeData 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description{ get; set; } 
      
    }
}