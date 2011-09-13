using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class AssociationTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Associations";
        private Constituent constituent;
        private TestDataHelper testDataHelper;
        private Association savedAssociation;
        private Constituent reciprocalConstituent;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            reciprocalConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba()));
            savedAssociation = testDataHelper.CreateAssociation(AsociationMother.JamesFranklinAndJessicaAlba(constituent,reciprocalConstituent));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteAssociations();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveConstituentAssociation()
        {
            var savedAssociationData = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id)
                , AssociationDataMother.JamesAndJessica(constituent,reciprocalConstituent));

            Assert.IsNotNull(savedAssociationData);
            Assert.That(savedAssociationData.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingConstituentAssociation()
        {
            var jamesAndJessica = AssociationDataMother.JamesAndJessica(constituent,reciprocalConstituent);

            var associationData = HttpHelper.Get<AssociationData>(string.Format("{0}/{1}", baseUri, savedAssociation.Id));
            associationData.AssociatedConstituentName = jamesAndJessica.AssociatedConstituentName;
            associationData.AssociatedConstituent = jamesAndJessica.AssociatedConstituent;

            var updatedAssociation = HttpHelper.Put(string.Format("{0}/{1}", baseUri, associationData.Id), associationData);

            Assert.That(updatedAssociation.AssociatedConstituent.Id, Is.EqualTo(jamesAndJessica.AssociatedConstituent.Id));
            Assert.That(updatedAssociation.AssociatedConstituentName, Is.EqualTo(jamesAndJessica.AssociatedConstituentName));
            Assert.That(updatedAssociation.Id, Is.EqualTo(associationData.Id));
        }

        [Test]
        public void ShouldDeleteAnExistingConstituentAssociation()
        {
            var response = HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, savedAssociation.Id));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var associationData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, savedAssociation.Id));
            Assert.That(associationData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void ShoulGetAnExistingConstituentAssociation()
        {
            var associationData = HttpHelper.Get<AssociationData>(string.Format("{0}/{1}", baseUri, savedAssociation.Id));
            Assert.That(associationData.AssociatedConstituent.Id, Is.EqualTo(savedAssociation.AssociatedConstituent.Id));
            Assert.That(associationData.AssociatedConstituentName, Is.EqualTo(savedAssociation.AssociatedConstituentName));
            Assert.That(associationData.StartDate, Is.EqualTo(savedAssociation.StartDate));
            Assert.That(associationData.EndDate, Is.EqualTo(savedAssociation.EndDate));
            Assert.That(associationData.Type.Id, Is.EqualTo(savedAssociation.Type.Id));
        }

        [Test]
        public void ShouldGetAllAssociationsForAConstituent()
        {
            var association = testDataHelper.CreateAssociation(AsociationMother.JamesFranklinAndParent(constituent));

            var associationsData = HttpHelper.Get<AssociationsData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(associationsData.Count, Is.EqualTo(2));
            Assert.That(associationsData.Exists(data => data.Id.Equals(association.Id)));
            Assert.That(associationsData.Exists(data => data.Id.Equals(savedAssociation.Id)));
        }
    }
}