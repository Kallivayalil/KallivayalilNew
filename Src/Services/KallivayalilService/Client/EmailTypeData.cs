using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [CollectionDataContract(Namespace = "")]
    public class EmailTypesData : List<EmailTypeData> {}

    [DataContract(Namespace = "")]
    public class EmailTypeData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}