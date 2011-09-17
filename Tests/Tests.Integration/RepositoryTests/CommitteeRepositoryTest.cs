using System;
using System.Data;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class CommitteeRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private CommitteeRepository committeeRepository;
        private Committee savedCommittee;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            committeeRepository = new CommitteeRepository(testDataHelper.session);
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            savedCommittee = testDataHelper.CreateCommittee(CommitteeMother.President(savedConstituent));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteCommittees();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveCommittee()
        {
            var committee = committeeRepository.Save(CommitteeMother.Secretary(savedConstituent));

            Assert.That(committee.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingCommittee()
        {
            var newEndDate = DateTime.Now.AddMonths(4);
            savedCommittee.EndDate = newEndDate;
            var updatedEmail = committeeRepository.Update(savedCommittee);

            Assert.That(updatedEmail.EndDate, Is.EqualTo(newEndDate));
        }

        [Test]
        public void ShouldLoadExistingCommittee()
        {
            var committee = committeeRepository.Load(savedCommittee.Id);

            Assert.IsNotNull(committee);
            Assert.That(committee.Id, Is.EqualTo(savedCommittee.Id));
        }


        [Test]
        public void ShouldLoadAllExistingCommittees()
        {
            testDataHelper.CreateCommittee(CommitteeMother.President(savedConstituent));

            var committees = committeeRepository.LoadAll<Committee>();
            Assert.That(committees.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldDeleteAnExistingCommittee()
        {
            committeeRepository.Delete(savedCommittee.Id);

            var committee = committeeRepository.Load(savedCommittee.Id);
            Assert.IsNull(committee);
        }



    }
}