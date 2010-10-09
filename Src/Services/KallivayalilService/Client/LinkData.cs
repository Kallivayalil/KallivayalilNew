using System.Runtime.Serialization;

namespace Kallivayalil.Client
{
    [DataContract(Namespace = "")]
    public class LinkData
    {
        [DataMember] 
        public string Href {get; set;}

        [DataMember]
        public int Id {get; set;}

        public static bool IsNull(LinkData linkData)
        {
            return (linkData == null || linkData.Id == 0);
        }
    }
}