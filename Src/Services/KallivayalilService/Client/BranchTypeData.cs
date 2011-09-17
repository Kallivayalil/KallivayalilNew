using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{

    [CollectionDataContract(Namespace = "")]
    public class BranchTypesData : List<BranchTypeData> { }

    [DataContract(Namespace = "")]
    public class BranchTypeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}