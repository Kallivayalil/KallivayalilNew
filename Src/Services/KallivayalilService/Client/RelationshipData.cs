using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class RelationshipData
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public TreeData data { get; set; }

        [DataMember]
        public List<RelationshipData> children { get; set; }
    }
}