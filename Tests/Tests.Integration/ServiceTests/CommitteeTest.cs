using System;
using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class CommitteeTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Committees";
        private Constituent constituent;
        private TestDataHelper testDataHelper;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
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
            var savedCommittee = HttpHelper.Post(string.Format("{0}", baseUri), CommitteeDataMother.President(constituent));

            Assert.IsNotNull(savedCommittee);
            Assert.That(savedCommittee.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingCommittee()
        {
            var committee = testDataHelper.CreateCommittee(CommitteeMother.President(constituent));

            var committeeData = CommitteeDataMother.President(constituent);
            var newEndDate = DateTime.Today.AddDays(5);
            committeeData.EndDate = newEndDate;
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, committee.Id), committeeData);

            Assert.That(updatedData.EndDate, Is.EqualTo(newEndDate));
        }

        [Test]
        public void ShouldLoadExitingCommittee()
        {
            var committee = testDataHelper.CreateCommittee(CommitteeMother.President(constituent));

            var committeeData = HttpHelper.Get<CommitteeData>(string.Format("{0}/{1}", baseUri, committee.Id));

            Assert.That(committeeData.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllCommittees()
        {
            testDataHelper.CreateCommittee(CommitteeMother.President(constituent));
            testDataHelper.CreateCommittee(CommitteeMother.President(constituent));
            testDataHelper.CreateCommittee(CommitteeMother.President(constituent));


            var committeesData = HttpHelper.Get<CommitteesData>(string.Format("{0}", baseUri));

            Assert.That(committeesData.Count, Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingCommittee()
        {
            var committee = testDataHelper.CreateCommittee(CommitteeMother.President(constituent));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, committee.Id));

            var committeeData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, committee.Id));
            Assert.That(committeeData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}