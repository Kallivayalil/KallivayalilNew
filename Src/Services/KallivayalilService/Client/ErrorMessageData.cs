using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class ErrorMessageData
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string ErrorPath { get; set; }

        [DataMember]
        public string Description { get; set; }
    }

    [CollectionDataContract(Namespace = "")]
    public class ErrorMessagesData : List<ErrorMessageData> { }
}