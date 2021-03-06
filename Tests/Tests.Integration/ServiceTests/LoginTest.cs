using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class LoginTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Authenticate";
        private TestDataHelper testDataHelper;

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteLogins();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldAuthenticateUser()
        {
            testDataHelper = new TestDataHelper();
            var isAuthenticated = HttpHelper.Get<bool>(string.Format("{0}?userName={1}&password={2}", baseUri, "james@franklin.com", "Password"));
            Assert.IsTrue(isAuthenticated);
        }


        [Test]
        public void ShouldLoadExistingLogin()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());

            var savedConstituent = testDataHelper.CreateConstituent(constituent);
            var email = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
            var login = testDataHelper.CreateUser(LoginMother.User(email, "Pass", false));

            var emailData = HttpHelper.Get<LoginData>(string.Format("{0}?username={1}", "http://localhost/kallivayalilService/KallivayalilService.svc/Login", email.Address));

            Assert.That(emailData.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingUser()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            var savedConstituent = testDataHelper.CreateConstituent(constituent);
            var email = testDataHelper.CreateEmail(EmailMother.Personal(savedConstituent, false));
            var login = testDataHelper.CreateUser(LoginMother.User(email,"Pass",false));

            var loginData = LoginDataMother.User(email,"Pass1",true);
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", "http://localhost/kallivayalilService/KallivayalilService.svc/Login", login.Id), loginData);

            Assert.That(updatedData.Email.Address, Is.EqualTo(email.Address));
            Assert.That(updatedData.Password, Is.EqualTo("Pass1"));
            Assert.That(updatedData.IsAdmin, Is.EqualTo(true));
        }


        [Test]
        public void ShouldSendMailForForgotPassword()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            var savedConstituent = testDataHelper.CreateConstituent(constituent);
            var email = testDataHelper.CreateEmail(EmailMother.Personal(savedConstituent, true));
            var login = testDataHelper.CreateUser(LoginMother.User(email, "Pass", false));

            var response = HttpHelper.DoHttpGet(string.Format("{0}?email={1}", "http://localhost/kallivayalilService/KallivayalilService.svc/Login/ForgotPassword",email.Address));
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ShouldThrowExceptionWhenMailIsInvalid()
        {
            testDataHelper = new TestDataHelper();
            var response = HttpHelper.DoHttpGet(string.Format("{0}?email={1}", "http://localhost/kallivayalilService/KallivayalilService.svc/Login/ForgotPassword","t@t.com"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}