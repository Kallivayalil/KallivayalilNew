using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Services;
using Kallivayalil.Client;

namespace Kallivayalil
{
    [ServiceContract]
    public interface IKallivayalilService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Constituents/{id}")]
        ConstituentData GetConstituent(string id);  
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents/{id}", Method = "DELETE")]
        void DeleteConstituent(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents" , Method = "POST")]
        ConstituentData CreateConstituent(ConstituentData constituentData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents/{id}", Method = "PUT")]
        ConstituentData UpdateConstituent(string id, ConstituentData constituentData);

    }
}
