using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class OccupationRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private Address savedAddress;
        private OccupationRepository occupationRepository;
        private Occupation savedOccupation;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            savedAddress = testDataHelper.CreateAddress(AddressMother.SanFrancisco(savedConstituent));
            occupationRepository = new OccupationRepository(testDataHelper.session);
            savedOccupation = testDataHelper.CreateOccupation(OccupationMother.Doctor(savedConstituent, savedAddress));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteOccupations();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveOccupation()
        {
            var occupation = occupationRepository.Save(OccupationMother.Doctor(savedConstituent));
            Assert.That(occupation.Id, Is.GreaterThan(0));
            Assert.IsNull(occupation.Address);
        }

        [Test]
        public void ShouldSavePhoneWithAddress()
        {
            var occupation = occupationRepository.Save(OccupationMother.Doctor(savedConstituent, savedAddress));
            Assert.That(occupation.Id, Is.GreaterThan(0));
            Assert.That(occupation.Address.Id, Is.EqualTo(savedAddress.Id));
        }

        [Test]
        public void ShouldUpdateExistingOccupation()
        {
            const string newOccupationName = "Lawyer";
            const string newDescription = "Senior Lawyer";

            savedOccupation.OccupationName = newOccupationName;
            savedOccupation.Description = newDescription;
            savedOccupation.Address = null;

            var updatedOccupation = occupationRepository.Update(savedOccupation);
            Assert.That(updatedOccupation.OccupationName, Is.EqualTo(newOccupationName));
            Assert.That(updatedOccupation.Description, Is.EqualTo(newDescription));
            Assert.IsNull(updatedOccupation.Address);
        }

        [Test]
        public void ShouldLoadExistingOccupation()
        {
            var occupation = occupationRepository.Load(savedOccupation.Id);

            Assert.IsNotNull(occupation);
            Assert.That(occupation.Id, Is.EqualTo(savedOccupation.Id));
        }

        [Test]
        public void ShouldDeleteExistingOccupation()
        {
            occupationRepository.Delete(savedOccupation.Id);

            var occupation = occupationRepository.Load(savedOccupation.Id);
            Assert.IsNull(occupation);
        }

        [Test]
        public void ShouldLoadAllOccupationsForConstituent()
        {
            testDataHelper.CreateOccupation(OccupationMother.Doctor(savedConstituent));

            var occupations = occupationRepository.LoadAll(savedConstituent);

            Assert.That(occupations.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllOccupationsForAnAddress()
        {
            testDataHelper.CreateOccupation(OccupationMother.Doctor(savedConstituent, savedAddress));

            var occupations = occupationRepository.LoadAll(savedAddress);

            Assert.That(occupations.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldSearchForOccupations()
        {
            var occupation = OccupationMother.Doctor(savedConstituent);
            var occupation1 = OccupationMother.Doctor(savedConstituent);
            occupation1.OccupationName = "test occ";
            occupation1.Description = "test occ desc";
            testDataHelper.CreateOccupation(occupation1);
            testDataHelper.CreateOccupation(occupation);

            var constituents = occupationRepository.SearchOccupationBy("test occ","test occ desc", false);

            Assert.That(constituents.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldSearchForOccupationsMatchAllCriteria()
        {
            var occupation = OccupationMother.Doctor(savedConstituent);
            var occupation1 = OccupationMother.Doctor(savedConstituent);
            occupation1.OccupationName = "test occ";
            occupation1.Description = "test occ desc";
            testDataHelper.CreateOccupation(occupation1);
            testDataHelper.CreateOccupation(occupation);

            var constituents = occupationRepository.SearchOccupationBy("test occ1","test occ desc", true);

            Assert.That(constituents.Count, Is.EqualTo(0));
        }

    }
}