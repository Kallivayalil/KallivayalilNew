using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ConstituentNameRepositoryTest
    {
        private ConstituentName jamesFranklin;
        private TestDataHelper testDataHelper;
        private ConstituentNameRepository repository;
        private ConstituentName savedConstituentName;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            repository = new ConstituentNameRepository(testDataHelper.session);

            jamesFranklin = ConstituentNameMother.JamesFranklin();
            savedConstituentName = testDataHelper.CreateConstituentName(jamesFranklin);
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveConstituentName()
        {
            var savedName = new ConstituentNameRepository().Save(jamesFranklin);

            Assert.That(savedName.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateConstituentName()
        {
            savedConstituentName.FirstName = "John";
            var johnFranklin = repository.Update(savedConstituentName);

            Assert.That(johnFranklin.FirstName, Is.EqualTo("John"));
        }

        [Test]
        public void ShouldDeleteConstituentName()
        {
            repository.Delete(savedConstituentName.Id);

            var constituentName = repository.Get<ConstituentName>(savedConstituentName.Id);
            Assert.IsNull(constituentName);
        }

        [Test]
        public void ShouldLoadConstituentName()
        {
            var james = repository.Load(savedConstituentName.Id);

            Assert.That(james.Id, Is.EqualTo(savedConstituentName.Id));
        }
    }
}