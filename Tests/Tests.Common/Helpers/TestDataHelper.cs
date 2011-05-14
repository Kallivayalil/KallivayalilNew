﻿using System;
using Kallivayalil.DataAccess;
using Kallivayalil.Domain;
using NHibernate;

namespace Tests.Common.Helpers
{
    public class TestDataHelper {
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
            sqlCommand.CommandText = "delete from constituents where id !=123";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteConstituentNames()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from constituentNames where id !=123";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public void HardDeleteAddress()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from addresses where id !=123";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Address CreateAddress(Address address)
        {
            var savedAddress = session.SaveOrUpdateCopy(address);
            session.Flush();
            return (Address)savedAddress;
        }

        public ConstituentName CreateConstituentName(ConstituentName constituentName)
        {
            var savedConstituentName = session.SaveOrUpdateCopy(constituentName);
            session.Flush();
            return (ConstituentName)savedConstituentName;            
        }

        public void HardDeletePhones()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from phones where id !=123";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Phone CreatePhone(Phone phone)
        {
            var savedPhone = session.SaveOrUpdateCopy(phone);
            session.Flush();
            return (Phone)savedPhone;
        }

        public void HardDeleteEmails()
        {
            var sqlCommand = session.Connection.CreateCommand();
            sqlCommand.CommandText = "delete from Emails where id !=123";
            sqlCommand.ExecuteNonQuery();
            session.Flush();
        }

        public Email CreateEmail(Email email)
        {
            var savedEmail = session.SaveOrUpdateCopy(email);
            session.Flush();
            return (Email)savedEmail;
        }
    }
}