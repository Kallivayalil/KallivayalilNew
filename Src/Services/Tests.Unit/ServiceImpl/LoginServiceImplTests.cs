using System.Collections.Generic;
using Kallivayalil;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Unit.ServiceImpl
{
    [TestFixture]
    public class LoginServiceImplTests
    {

        [Test]
        public void ShouldSendMailForForgotPasswordIfEmailIsAValidUserName()
        {
            var emailRepository = MockRepository.GenerateMock<IEmailRepository>();
            var loginRepository = MockRepository.GenerateMock<ILoginRepository>();
            var mail = MockRepository.GenerateMock<IMail>();
            var email = "a@b.com";
            var loginServiceImpl = new LoginServiceImpl(loginRepository,emailRepository,mail);

            var emailMatch = new Email {Address = email,Id = 11,IsPrimary = true};
            var login = new Login {Email = emailMatch,Password = "Pass"};
            
            emailRepository.Stub(repository => repository.Load(email)).Return(emailMatch);
            loginRepository.Stub(repository1 => repository1.Load(emailMatch)).Return(login);

            loginServiceImpl.ForgotPassword(email);

            mail.AssertWasCalled(mail1 => mail1.Send(email, "Reply: Forgot Password Request", string.Format("Dear Ma'am/Sir, \r\n Username:{0} \r\n Password:{1} \r\n Regards, \r\n Admin team.", email, login.Password)));



        }
    }
}