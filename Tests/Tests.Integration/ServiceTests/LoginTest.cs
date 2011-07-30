using Kallivayalil.Client;
using NUnit.Framework;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class LoginTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Authenticate";

        [Test]
        public void ShouldAuthenticateUser()
        {
            var isAuthenticated = HttpHelper.Get<bool>(string.Format("{0}?userName={1}&password={2}", baseUri, "james@franklin.com", "Password"));
            Assert.IsTrue(isAuthenticated);
        }
    }
}