using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ConstituentRepositoryTest
    {
        private Constituent constituent;
        private ConstituentRepository constituentRepository;

        [SetUp]
        public void SetUp()
        {
            constituent = new Constituent { Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            constituent.Name = ConstituentNameMother.JamesFranklin();

            constituentRepository = new ConstituentRepository();

        }

        [Test]
        public void ShouldSaveAConstituent()
        {
            var savedConstituent = constituentRepository.Save(constituent);

            Assert.That(savedConstituent.Id,Is.GreaterThan(0));
            Assert.That(savedConstituent.Name.Id,Is.GreaterThan(0));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.EqualTo(savedConstituent.UpdatedDateTime));
            Assert.That(savedConstituent.Name.CreatedDateTime, Is.EqualTo(savedConstituent.CreatedDateTime));

            constituentRepository.Delete(savedConstituent);
        }
        
        [Test]
        public void ShouldUpdateAnExistingConstituent()
        {
            var savedConstituent = constituentRepository.Save(constituent);

            savedConstituent.Gender = "F";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Gender, Is.EqualTo("F"));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.Not.EqualTo(savedConstituent.UpdatedDateTime));
            Assert.That(savedConstituent.UpdatedDateTime, Is.Not.Null);
            Assert.That(savedConstituent.UpdatedBy, Is.Not.Null);
            
            constituentRepository.Delete(updatedConstituent);
        }

        [Test]
        public void ShouldUpdateAnExistingConstituentName()
        {
            var savedConstituent = constituentRepository.Save(constituent);

            savedConstituent.Name.MiddleName = "Einstein";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Name.MiddleName, Is.EqualTo("Einstein"));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.Not.EqualTo(savedConstituent.UpdatedDateTime));
            
            constituentRepository.Delete(updatedConstituent);
        }

        [Test]
        public void ShouldDeleteAConstituent()
        {
            var savedConstituent = constituentRepository.Save(constituent);
            constituentRepository.Delete(savedConstituent.Id);

            Assert.That(constituentRepository.Exists(savedConstituent),Is.False);
        }

        [Test]
        public void ShouldLoadConstituentForTheGivenId()
        {
            var savedConstituent = constituentRepository.Save(constituent);
            var result = constituentRepository.Load(savedConstituent.Id);

            Assert.IsNotNull(result);
            Assert.That(result,Is.TypeOf(typeof(Constituent)));
            Assert.That(result.Id,Is.EqualTo(savedConstituent.Id));
        }

    }
}
