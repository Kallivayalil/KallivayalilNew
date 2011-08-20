using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ConstituentRepositoryTest
    {
        private Constituent constituent;
        private ConstituentRepository constituentRepository;
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;


        [SetUp]
        public void SetUp()
        {
//            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            testDataHelper = new TestDataHelper();

            constituent = new Constituent {Gender = "M", BornOn = DateTime.Today, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituent.Name = ConstituentNameMother.JamesFranklin();
            savedConstituent = testDataHelper.CreateConstituent(constituent);

            constituentRepository = new ConstituentRepository();
        }


        [TearDown]
        public void TearDown()
        {
            testDataHelper.session.Clear();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldSaveAConstituent()
        {
            var savedConst = constituentRepository.Save(constituent);

            Assert.That(savedConst.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Name.Id, Is.GreaterThan(0));
            constituentRepository.Delete(savedConst);
        }

        [Test]
        public void ShouldUpdateAnExistingConstituent()
        {
            
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
            savedConstituent.Name.MiddleName = "Einstein";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Name.MiddleName, Is.EqualTo("Einstein"));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.Not.EqualTo(savedConstituent.UpdatedDateTime));

            constituentRepository.Delete(updatedConstituent);
        }

        [Test]
        public void ShouldDeleteAConstituent()
        {
            constituentRepository.Delete(savedConstituent.Id);

            Assert.That(constituentRepository.Exists(savedConstituent), Is.False);
        }


        [Test]
        public void ShouldLoadConstituentForTheGivenId()
        {
            var result = constituentRepository.Load(savedConstituent.Id);

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf(typeof (Constituent)));
            Assert.That(result.Id, Is.EqualTo(savedConstituent.Id));
        }

        [Test]
        public void ShouldLoadAllConstituentsWithBirthdayToday()
        {
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JessicaAlba()));

            var constituents = constituentRepository.LoadAllConstituentsWithBirthdayToday();

            Assert.That(constituents.Count,Is.EqualTo(2));
        }


        [Test,Ignore("WIP")]
        public void ShouldSearchConstituentByName()
        {
            testDataHelper.CreateConstituent(constituent);
            var result = constituentRepository.SearchByName("james","james");

            Assert.That(result.Count(), Is.EqualTo(3));
        }

    }
}