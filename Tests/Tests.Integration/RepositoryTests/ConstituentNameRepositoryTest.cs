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

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            jamesFranklin = ConstituentNameMother.JamesFranklin();
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveConstituentName()
        {            
            var savedConstituentName = new ConstituentNameRepository().Save(jamesFranklin);

            Assert.That(savedConstituentName.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateConstituentName()
        {
            var repository = new ConstituentNameRepository();
            var constituentName = repository.Save(jamesFranklin);

            constituentName.FirstName = "John";
            var johnFranklin = repository.Update(constituentName);

            Assert.That(johnFranklin.FirstName,Is.EqualTo("John"));
        }

        [Test]
        public void ShouldDeleteConstituentName()
        {
            var repository = new ConstituentNameRepository();
            var savedJames = repository.Save(jamesFranklin);

            repository.Delete(savedJames.Id);

            var constituentName = repository.Get<ConstituentName>(savedJames.Id);
            Assert.IsNull(constituentName);
        }

        [Test]
        public void ShouldLoadConstituentName()
        {
            var repository = new ConstituentNameRepository();
            var savedJames = repository.Save(jamesFranklin);

            var james = repository.Load(savedJames.Id);

            Assert.That(james.Id,Is.EqualTo(savedJames.Id));

        }
    }
}