﻿using System.ServiceModel;
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
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/ConstituentNames/{id}", Method = "PUT")]
        ConstituentNameData UpdateConstituentName(string id, ConstituentNameData nameData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Addresses?constituentId={constituentId}", Method = "POST")]
        AddressData CreateAddress(string constituentId, AddressData addressData);
       
        [OperationContract]
        [WebInvoke(UriTemplate = "/Addresses/{id}", Method = "PUT")]
        AddressData UpdateAddress(string id, AddressData addressData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Addresses/{id}", Method = "DELETE")]
        void DeleteAddress(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Addresses/{id}")]
        AddressData GetAddress(string id);  
        
        [OperationContract]
        [WebGet(UriTemplate = "/Addresses?constituentId={constituentId}")]
        AddressesData GetAddresses(string constituentId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Phones?constituentId={constituentId}", Method = "POST")]
        PhoneData CreatePhone(string constituentId, PhoneData phoneData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Phones?constituentId={constituentId}", Method = "PUT")]
        PhoneData UpdatePhone(string constituentId, PhoneData phoneData);

        [OperationContract]
        [WebGet(UriTemplate = "/Phones/{id}")]
        PhoneData GetPhone(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Phones/{id}", Method = "DELETE")]
        void DeletePhone(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Phones?constituentId={constituentId}")]
        PhonesData GetPhones(string constituentId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Emails?constituentId={constituentId}", Method = "POST")]
        EmailData CreateEmail(string constituentId, EmailData emailData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Emails?constituentId={constituentId}", Method = "PUT")]
        EmailData UpdateEmail(string constituentId, EmailData emailData);

        [OperationContract]
        [WebGet(UriTemplate = "/Emails/{id}")]
        EmailData GetEmail(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Emails/{id}", Method = "DELETE")]
        void DeleteEmail(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Emails?constituentId={constituentId}")]
        EmailsData GetEmails(string constituentId);

    }
}
