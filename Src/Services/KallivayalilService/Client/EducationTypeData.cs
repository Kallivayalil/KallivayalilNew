using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class EducationTypesData : List<EducationTypeData> { }

    [DataContract(Namespace = "")]
    public class EducationTypeData 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description{ get; set; } 
      
    }
}