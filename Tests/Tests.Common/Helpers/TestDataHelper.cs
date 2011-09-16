using System;
using Kallivayalil.DataAccess;
using Kallivayalil.Domain;
using NHibernate;

namespace Tests.Common.Helpers
{
    public class TestDataHelper
    {
        public readonly ISession session;

        public TestDataHelper()
        {
            session = ConfigurationFactory.SessionFactory.OpenSession();
        }

        public Constituent CreateConstituent(Constituent constituent)
        {
            var savedConstituent = session.SaveOrUpdateCopy(constituent);
            session.Flush();
            return (Constituent) savedConstituent;
        }

        public void HardDeleteConstituents()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from constituents where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteConstituentNames()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from constituentNames where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }


        public void HardDeleteEvents()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from events where id !=0";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteAddress()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from addresses where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Address CreateAddress(Address address)
        {
            var savedAddress = session.SaveOrUpdateCopy(address);
            session.Flush();
            return (Address) savedAddress;
        }

        public ConstituentName CreateConstituentName(ConstituentName constituentName)
        {
            var savedConstituentName = session.SaveOrUpdateCopy(constituentName);
            session.Flush();
            return (ConstituentName) savedConstituentName;
        }

        public void HardDeletePhones()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from phones where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteContactUs()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from contactus where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }


        public void HardDeleteOccupations()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from occupations where id >= 10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteEducationDetails()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from educationdetails where id >=10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Phone CreatePhone(Phone phone)
        {
            var savedPhone = session.SaveOrUpdateCopy(phone);
            session.Flush();
            return (Phone) savedPhone;
        }

        public Occupation CreateOccupation(Occupation occupation)
        {
            var savedOccupation = session.SaveOrUpdateCopy(occupation);
            session.Flush();
            return (Occupation) savedOccupation;
        }

        public EducationDetail CreateEducationDetail(EducationDetail educationDetail)
        {
            var savedEducationDetail = session.SaveOrUpdateCopy(educationDetail);
            session.Flush();
            return (EducationDetail) savedEducationDetail;
        }

        public void HardDeleteEmails()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from Emails where id >=10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }
       
        
        public void HardDeleteLogins()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from Logins where email >=10";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Email CreateEmail(Email email)
        {
            var savedEmail = session.SaveOrUpdateCopy(email);
            session.Flush();
            return (Email) savedEmail;
        }

        public void HardDeleteAssociations()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from Associations where id >=20 or reciprocalid >=20";
            sqlCommand.ExecuteNonQuery();
            session.Flush();

        }

        public Association CreateAssociation(Association association)
        {
            var savedAssociation = session.SaveOrUpdateCopy(association);
            session.Flush();
            return (Association)savedAssociation; 
        }

        public Event CreateEvent(Event @event)
        {
            var savedEvent = session.SaveOrUpdateCopy(@event);
            session.Flush();
            return (Event)savedEvent; 
        }

        public ContactUs CreateContactUs(ContactUs contactUs)
        {
            var savedContactUs = session.SaveOrUpdateCopy(contactUs);
            session.Flush();
            return (ContactUs)savedContactUs; 
        }
    }
}