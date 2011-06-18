using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{

    [CollectionDataContract(Namespace = "")]
    public class PhoneTypesData : List<PhoneTypeData> { }

    [DataContract(Namespace = "")]
    public class PhoneTypeData 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description{ get; set; } 
      
    }
}