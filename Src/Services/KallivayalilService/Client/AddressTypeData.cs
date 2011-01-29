using System;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class AddressTypeData 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description{ get; set; } 
      
    }
}