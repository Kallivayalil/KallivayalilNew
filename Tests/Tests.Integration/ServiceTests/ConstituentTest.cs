using System;
using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ConstituentTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Constituents";
        private TestDataHelper testDataHelper;
        private Constituent constituent;
        private ConstituentData constituentData;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JessicaAlba()));
            constituentData = new ConstituentData {Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituentData.Name = new ConstituentNameData {FirstName = "James", LastName = "Franklin", Salutation = new SalutationTypeData {Id = 1, Description = "Mr"}};
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldLoadConstituent()
        {
            var result = HttpHelper.Get<ConstituentData>(string.Format("{0}/{1}", baseUri, constituent.Id));
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldCreateConstituent()
        {
            var savedConstituent = HttpHelper.Post(baseUri, constituentData);

            Assert.IsNotNull(savedConstituent);
            Assert.That(savedConstituent.Id, Is.GreaterThan(0));
            Assert.That(savedConstituent.Name.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateConstituent()
        {
            var savedConstituent = HttpHelper.Post(baseUri, constituentData);

            savedConstituent.Gender = "M";
            savedConstituent.BranchName = 3;
            savedConstituent.IsRegistered = true;

            var updatedConstituentData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, savedConstituent.Id), savedConstituent);
            Assert.IsNotNull(updatedConstituentData);
            Assert.That(updatedConstituentData.Id, Is.EqualTo(savedConstituent.Id));
            Assert.That(updatedConstituentData.Gender, Is.EqualTo("M"));
            Assert.That(updatedConstituentData.BranchName, Is.EqualTo(3));
            Assert.That(updatedConstituentData.IsRegistered, Is.EqualTo(true));
        }

        [Test]
        public void ShouldDeleteExistingConstituent()
        {
            var response = HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, constituent.Id));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var getResponse = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, constituent.Id));
            Assert.IsNotNull(getResponse);
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void ShouldCreateConstituentWithName()
        {
            var savedConstituent = HttpHelper.Post(baseUri, constituentData);

            Assert.That(savedConstituent.Id, Is.GreaterThan(0));
            Assert.That(savedConstituent.Name.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldGetAllConstituents()
        {
            var result = HttpHelper.Get<ConstituentsData>(baseUri);

            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}