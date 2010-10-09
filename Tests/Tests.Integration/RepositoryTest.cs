using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;

namespace Tests.Integration
{
    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void ShouldSaveAConstituent()
        {
            var constituent = new Constituent {Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            var constituentRepository = new ConstituentRepository();

            var savedConstituent = constituentRepository.Save(constituent);

            Assert.That(savedConstituent.Id,Is.GreaterThan(0));
            constituentRepository.Delete(savedConstituent);

        }
    }
}
