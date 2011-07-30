using Kallivayalil.DataAccess;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class LoginRepositoryTest
    {
        private Email savedEmail;
        private LoginRepository loginRepository;

        [SetUp]
        public void SetUp()
        {
            savedEmail = new Email {Id = 0};
            loginRepository = new LoginRepository(ConfigurationFactory.SessionFactory.OpenSession());
        }

        [Test]
        public void ShouldGetExistingUserLogin()
        {
            var login = loginRepository.Load(savedEmail);

            Assert.IsNotNull(login);
            Assert.That(login.Email, Is.EqualTo(savedEmail));
            Assert.IsNotNull(login.Password);
            Assert.That(login.Password, Is.EqualTo("Password"));
        }

        [Test]
        public void ShouldAuthenticateUser()
        {
            var login = loginRepository.Load(savedEmail);
            var authenticate = loginRepository.Authenticate(login, "Password");
            Assert.IsTrue(authenticate);
        }
    }
}