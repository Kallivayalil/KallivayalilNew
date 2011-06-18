using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain.ReferenceData;
using NUnit.Framework;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ReferenceDataRepositoryTest
    {
        private ReferenceDataRepository repo;

        [SetUp]
        public void SetUp()
        {
            repo = new ReferenceDataRepository();
        }

        [Test]
        public void ShouldLoadAllPhoneTypes()
        {
            var phoneTypes = repo.LoadAll<PhoneType>();

            Assert.NotNull(phoneTypes);
            Assert.That(phoneTypes.Count,Is.EqualTo(2));

        }
    }
}