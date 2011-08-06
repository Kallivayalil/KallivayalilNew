using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{

    [CollectionDataContract(Namespace = "")]
    public class EventsData : List<EventData> {}


    [DataContract(Namespace = "")]
    public class EventData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public  string EventTitle { get; set; }

        [DataMember]
        public  string EventDescription { get; set; }

        [DataMember]
        public  EventTypeData Type { get; set; }

        [DataMember]
        public  bool IsApproved { get; set; }

        [DataMember]
        public  string ContactPerson { get; set; }

        [DataMember]
        public  string ContactNumber { get; set; }

        [DataMember]
        public LinkData Constituent { get; set; }
        
        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

    }
}