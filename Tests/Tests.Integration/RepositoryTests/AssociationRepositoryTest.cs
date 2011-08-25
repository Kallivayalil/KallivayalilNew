using System.Linq;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class AssociationRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private AssociationRepository associationRepository;
        private Constituent savedAssociatedConstituent;
        private Association savedAssociation;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            
            constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JessicaAlba());
            savedAssociatedConstituent = testDataHelper.CreateConstituent(constituent);

            savedAssociation = testDataHelper.CreateAssociation(AsociationMother.JamesFranklinAndParent(savedConstituent));

            associationRepository = new AssociationRepository(testDataHelper.session);
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.session.Clear();
            testDataHelper.HardDeleteAssociations();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveConstituentAssociation()
        {
            var association = associationRepository.Save(AsociationMother.JamesFranklinAndJessicaAlba(savedConstituent, savedAssociatedConstituent));

            Assert.That(association.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateTheSavedConstituentAssociation()
        {
            var franklin = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.Franklin()));
            savedAssociation.AssociatedConstituent = franklin;
            savedAssociation.AssociatedConstituentName = string.Empty;

            var updatedAssociation = associationRepository.Update(savedAssociation);

            Assert.That(updatedAssociation.AssociatedConstituent, Is.EqualTo(franklin));
            Assert.That(updatedAssociation.AssociatedConstituentName, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ShouldDeleteAnExistingAssociation()
        {
            associationRepository.Delete(savedAssociation.Id);

            var association = associationRepository.Get<Association>(savedAssociation.Id);
            Assert.IsNull(association);
        }

        [Test]
        public void ShouldGetExistingAssociation()
        {
            var association = associationRepository.Load(savedAssociation.Id);

            Assert.IsNotNull(association);
            Assert.That(association.AssociatedConstituent, Is.EqualTo(savedAssociation.AssociatedConstituent));
            Assert.That(association.Id, Is.EqualTo(savedAssociation.Id));
        }

        [Test]
        public void ShouldLoadAllConstituentsWithAnniversayToday()
        {
            testDataHelper.CreateAssociation(AsociationMother.JamesFranklinAndJessicaAlba(savedConstituent,savedAssociatedConstituent));
            testDataHelper.CreateAssociation(AsociationMother.JamesFranklinAndJessicaAlba(savedConstituent,savedAssociatedConstituent));

            var constituents = associationRepository.LoadAllConstituentsWithAnniversaryToday();

            Assert.IsNotNull(constituents);
            Assert.That(constituents.Count, Is.EqualTo(2));
        }

       

    }
}