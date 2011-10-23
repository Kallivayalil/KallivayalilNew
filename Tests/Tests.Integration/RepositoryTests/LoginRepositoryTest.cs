using Kallivayalil.DataAccess;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class LoginRepositoryTest
    {
        private Email savedEmail;
        private LoginRepository loginRepository;
        private TestDataHelper testDataHelper;

        [SetUp]
        public void SetUp()
        {
            savedEmail = new Email {Id = 1};
            loginRepository = new LoginRepository(ConfigurationFactory.SessionFactory.OpenSession());
            testDataHelper = new TestDataHelper();
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteLogins();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeleteConstituents();
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
        public void ShouldAuthenticateRegisteredUser()
        {
            var login = loginRepository.Load(savedEmail);
            var authenticate = loginRepository.Authenticate(login, "Password");
            Assert.IsTrue(authenticate);
        }  
        
        [Test]
        public void ShouldNotAuthenticateNonRegisteredUser()
        {
            var constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(),'A'));
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));
            var login = new Login
                            {
                                Email = email,
                                IsAdmin = false,
                                Password = "Password"
                            };
            var savedLogin = loginRepository.Save(login);
            var authenticate = loginRepository.Authenticate(savedLogin, "Password");
            Assert.IsFalse(authenticate);
        }

        [Test]
        public void ShouldCreateALoginAsNonAdminByDefault()
        {
            var constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var login = new Login(){Email = email,Password = "somepass"};
            var savedLogin = loginRepository.Save(login);

            Assert.That(savedLogin.Id,Is.GreaterThan(0));
            Assert.IsFalse(savedLogin.IsAdmin);
        } 
        
        [Test]
        public void ShouldCreateALoginAsAdmin()
        {
            var constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var login = new Login {Email = email,Password = "somepass", IsAdmin = true};
            var savedLogin = loginRepository.Save(login);

            Assert.That(savedLogin.Id,Is.GreaterThan(0));
            Assert.IsTrue(savedLogin.IsAdmin);
        }

        [Test]
        public void ShouldUpdateALoginAsAdmin()
        {
            var constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var login = new Login {Email = email,Password = "somepass", IsAdmin = false};
            var savedLogin = loginRepository.Save(login);

            Assert.That(savedLogin.Id,Is.GreaterThan(0));
            Assert.IsFalse(savedLogin.IsAdmin);

            savedLogin.IsAdmin = true;
            var updatedLogin = loginRepository.Update(savedLogin);

            Assert.IsTrue(updatedLogin.IsAdmin);
        }



    }
}