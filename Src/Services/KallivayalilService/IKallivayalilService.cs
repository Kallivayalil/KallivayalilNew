﻿using System.ServiceModel;
using System.ServiceModel.Web;
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
        [WebGet(UriTemplate = "/Constituents")]
        ConstituentsData GetConstituents();

        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents/{id}", Method = "DELETE")]
        void DeleteConstituent(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents", Method = "POST")]
        ConstituentData CreateConstituent(ConstituentData constituentData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Constituents/{id}", Method = "PUT")]
        ConstituentData UpdateConstituent(string id, ConstituentData constituentData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConstituentNames/{id}", Method = "PUT")]
        ConstituentNameData UpdateConstituentName(string id, ConstituentNameData nameData); 
        
        [OperationContract]
        [WebGet(UriTemplate = "/Constituents?firstName={firstName}&lastName={lastName}")]
        ConstituentsData SearchByConstituentName(string firstName, string lastName);

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
        [WebInvoke(UriTemplate = "/Phones/{id}", Method = "PUT")]
        PhoneData UpdatePhone(string id, PhoneData phoneData);

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
        [WebInvoke(UriTemplate = "/Emails/{id}", Method = "PUT")]
        EmailData UpdateEmail(string id, EmailData emailData);

        [OperationContract]
        [WebGet(UriTemplate = "/Emails/{id}")]
        EmailData GetEmail(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Emails/{id}", Method = "DELETE")]
        void DeleteEmail(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Emails?constituentId={constituentId}")]
        EmailsData GetEmails(string constituentId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/EducationDetails?constituentId={constituentId}", Method = "POST")]
        EducationDetailData CreateEducationDetail(string constituentId, EducationDetailData educationDetailData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/EducationDetails/{id}", Method = "PUT")]
        EducationDetailData UpdateEducationDetail(string id, EducationDetailData educationDetailData);

        [OperationContract]
        [WebGet(UriTemplate = "/EducationDetails/{id}")]
        EducationDetailData GetEducationDetail(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/EducationDetails/{id}", Method = "DELETE")]
        void DeleteEducationDetail(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/EducationDetails?constituentId={constituentId}")]
        EducationDetailsData GetEducationDetails(string constituentId);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Occupations?constituentId={constituentId}", Method = "POST")]
        OccupationData CreateOccupation(string constituentId, OccupationData occupationData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Occupations/{id}", Method = "PUT")]
        OccupationData UpdateOccupation(string id, OccupationData occupationData);

        [OperationContract]
        [WebGet(UriTemplate = "/Occupations/{id}")]
        OccupationData GetOccupation(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Occupations/{id}", Method = "DELETE")]
        void DeleteOccupation(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Occupations?constituentId={constituentId}")]
        OccupationsData GetOccupations(string constituentId);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Associations?constituentId={constituentId}", Method = "POST")]
        AssociationData CreateAssociation(string constituentId, AssociationData occupationData);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Associations/{id}", Method = "PUT")]
        AssociationData UpdateAssociation(string id, AssociationData occupationData);

        [OperationContract]
        [WebGet(UriTemplate = "/Associations/{id}")]
        AssociationData GetAssociation(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Associations/{id}", Method = "DELETE")]
        void DeleteAssociation(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Associations?constituentId={constituentId}")]
        AssociationsData GetAssociations(string constituentId);


        [OperationContract]
        [WebGet(UriTemplate = "/OccupationTypes")]
        OccupationTypesData GetOccupationTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/EducationTypes")]
        EducationTypesData GetEducationTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/PhoneTypes")]
        PhoneTypesData GetPhoneTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/EmailTypes")]
        EmailTypesData GetEmailTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/AddressTypes")]
        AddressTypesData GetAddressTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/SalutationTypes")]
        SalutationTypesData GetSalutationTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/Authenticate?username={username}&password={password}")]
        bool Authenticate(string username, string password);
    }
}