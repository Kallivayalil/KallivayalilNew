using System;
using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ConstituentNameTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/ConstituentNames";

        [Test]
        public void ShouldUpdateConstituentName()
        {
            var constituent = new TestDataHelper().CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));

            constituent.Name.FirstName = "John";
            constituent.Name.LastName = "Smith";
            AutoDataContractMapper mapper = new AutoDataContractMapper();
            var nameData = new ConstituentNameData();
            mapper.Map(constituent.Name,nameData);
            var constituentName = HttpHelper.Put(string.Format("{0}/{1}",baseUri,nameData.Id),nameData);

            Assert.IsNotNull(constituentName);
            Assert.That(constituentName.FirstName,Is.EqualTo("John"));
            Assert.That(constituentName.LastName,Is.EqualTo("Smith"));
        }


    }
}