﻿using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ConstituentRepositoryTest
    {
        [Test]
        public void ShouldSaveAConstituent()
        {
            var constituent = new Constituent {Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            var constituentRepository = new ConstituentRepository();

            var savedConstituent = constituentRepository.Save(constituent);

            Assert.That(savedConstituent.Id,Is.GreaterThan(0));
            Assert.That(savedConstituent.CreatedDateTime,Is.Not.Null);
            Assert.That(savedConstituent.CreatedBy,Is.Not.Null);
            Assert.That(savedConstituent.UpdatedDateTime,Is.Not.Null);
            Assert.That(savedConstituent.UpdatedBy,Is.Not.Null);
            constituentRepository.Delete(savedConstituent);

        }
        
        [Test]
        public void ShouldUpdateAnExistingConstituent()
        {
            var constituent = new Constituent { Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            var constituentRepository = new ConstituentRepository();

            var savedConstituent = constituentRepository.Save(constituent);

            savedConstituent.Gender = "F";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Gender, Is.EqualTo("F"));
            Assert.That(savedConstituent.UpdatedDateTime, Is.Not.Null);
            Assert.That(savedConstituent.UpdatedBy, Is.Not.Null);
            
            constituentRepository.Delete(updatedConstituent);
        }

        [Test]
        public void ShouldDeleteAConstituent()
        {
            var constituent = new Constituent { Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            var constituentRepository = new ConstituentRepository();

            var savedConstituent = constituentRepository.Save(constituent);
            constituentRepository.Delete(savedConstituent.Id);

            Assert.That(constituentRepository.Exists(savedConstituent),Is.False);
        }

        [Test]
        public void ShouldLoadConstituentForTheGivenId()
        {
            var constituent = new Constituent { Gender = "M", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            var constituentRepository = new ConstituentRepository();

            var savedConstituent = constituentRepository.Save(constituent);
            var result = constituentRepository.Load(savedConstituent.Id);

            Assert.IsNotNull(result);
            Assert.That(result,Is.TypeOf(typeof(Constituent)));
            Assert.That(result.Id,Is.EqualTo(savedConstituent.Id));


        }
    }
}
