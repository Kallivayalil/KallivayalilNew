using Kallivayalil.Client;
using NUnit.Framework;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ReferenceDataTest
    {
        private const string BaseUri = "http://localhost/kallivayalilService/KallivayalilService.svc";

        [Test]
        public void ShouldLoadAllPhoneTypes()
        {
            var phoneTypes = HttpHelper.Get<PhoneTypesData>(string.Format("{0}/{1}", BaseUri, "PhoneTypes"));

            Assert.That(phoneTypes.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllEmailTypes()
        {
            var emailTypes = HttpHelper.Get<EmailTypesData>(string.Format("{0}/{1}", BaseUri, "EmailTypes"));

            Assert.That(emailTypes.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllAddressTypes()
        {
            var addressTypes = HttpHelper.Get<AddressTypesData>(string.Format("{0}/{1}", BaseUri, "AddressTypes"));

            Assert.That(addressTypes.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllSalutationTypes()
        {
            var salutationTypes = HttpHelper.Get<SalutationTypesData>(string.Format("{0}/{1}", BaseUri, "SalutationTypes"));

            Assert.That(salutationTypes.Count, Is.EqualTo(3));
        } 
        
        [Test]
        public void ShouldLoadAllEventTypes()
        {
            var salutationTypes = HttpHelper.Get<EventTypesData>(string.Format("{0}/{1}", BaseUri, "EventTypes"));

            Assert.That(salutationTypes.Count, Is.EqualTo(2));
        } 
        
        [Test]
        public void ShouldLoadAllBranchTypes()
        {
            var branchTypesData = HttpHelper.Get<BranchTypesData>(string.Format("{0}/{1}", BaseUri, "BranchTypes"));

            Assert.That(branchTypesData.Count, Is.EqualTo(3));
        }
        
        [Test]
        public void ShouldLoadAllPositionTypes()
        {
            var positionTypesData = HttpHelper.Get<PositionTypesData>(string.Format("{0}/{1}", BaseUri, "PositionTypes"));

            Assert.That(positionTypesData.Count, Is.EqualTo(6));
        }
    }
}