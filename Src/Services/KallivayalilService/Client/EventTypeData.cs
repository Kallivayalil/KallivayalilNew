
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class EventTypeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }

    [CollectionDataContract(Namespace = "")]
    public class EventTypesData : List<EventTypeData> {}

}