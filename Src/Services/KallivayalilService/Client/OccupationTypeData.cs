using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class OccupationTypesData : List<OccupationTypeData> {}

    [DataContract(Namespace = "")]
    public class OccupationTypeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}