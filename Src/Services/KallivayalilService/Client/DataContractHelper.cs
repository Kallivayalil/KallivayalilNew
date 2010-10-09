using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Kallivayalil.Client
{
    public class DataContractHelper
    {
        public T Deserialize<T>(string xmlData)
        {
            var serializer = new DataContractSerializer(typeof(T), null, int.MaxValue, false, true, null);
            using (var stringReader = new StringReader(xmlData))
            using (var xmlTextReader = new XmlTextReader(stringReader))
            {
                return (T)serializer.ReadObject(xmlTextReader);
            }
        }

        public string Serialize<T>(T data)
        {
            using (var writer = new StringWriter())
            using (XmlWriter xmlWriter = new XmlTextWriter(writer))
            {
                var ser = new DataContractSerializer(typeof(T));
                ser.WriteObject(xmlWriter, data);
                return writer.ToString();
            }
        }
    }
}