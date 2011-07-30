using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class SalutationTypesData : List<SalutationTypeData> {}

    [DataContract(Namespace = "")]
    public class SalutationTypeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}