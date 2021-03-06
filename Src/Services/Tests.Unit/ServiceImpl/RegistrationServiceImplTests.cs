﻿using System.Collections.Generic;
using Kallivayalil;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests.Unit.ServiceImpl
{
    [TestFixture]
    public class RegistrationServiceImplTests
    {
        [Test]
        public void ShouldRegisterAConstituent()
        {
            var mail = MockRepository.GenerateMock<IMail>();
            var repository = MockRepository.GenerateMock<IRegisterationRepository>();
            var constituentRepository = MockRepository.GenerateMock<IConstituentRepository>(null);
            var emailServiceImpl = MockRepository.GenerateMock<IEmailServiceImpl>();
            var  phoneServiceImpl = MockRepository.GenerateMock<IPhoneServiceImpl>();
            var  addressServiceImpl = MockRepository.GenerateMock<IAddressServiceImpl>();
            var loginServiceImpl = MockRepository.GenerateMock<ILoginServiceImpl>();

            var registrationServiceImpl = new RegistrationServiceImpl(repository, constituentRepository, mail, emailServiceImpl, phoneServiceImpl, addressServiceImpl, loginServiceImpl);

            var existingConstituent = new Constituent {Id = 11};
            var newConstituent = new Constituent {Id = 12};
            var email = new Email { Address = "a@b.com" };
            var adminEmail = "x@y.com";

            constituentRepository.Stub(repository1 => repository1.Load(11)).Return(existingConstituent);
            constituentRepository.Stub(repository1 => repository1.Load(12)).Return(newConstituent);
            constituentRepository.Stub(repository1 => repository1.Update(existingConstituent)).Return(existingConstituent);
            constituentRepository.Stub(repository1 => repository1.Delete(newConstituent.Id));

            emailServiceImpl.Stub(impl => impl.SetConstituentAndUpdateEmail("12", existingConstituent));
            phoneServiceImpl.Stub(impl => impl.SetConstituentAndUpdatePhone("12", existingConstituent));
            addressServiceImpl.Stub(impl => impl.SetConstituentAndUpdateAddress("12", existingConstituent));
            loginServiceImpl.Stub(impl => impl.UpdateAsAdmin(false,existingConstituent.Id));
            emailServiceImpl.Stub(impl => impl.FindEmails(existingConstituent.Id.ToString())).Return(new List<Email> { email });

            mail.Stub(mail1 => mail1.Send(email.Address, "Kallivayalil Account Activated", "Your Account has been activated."));
            mail.Stub(mail1 => mail1.Send(adminEmail, "Kallivayalil Account Activated", string.Format("Account-{0} has been activated.", email.Address)));

            registrationServiceImpl.RegisterConstituent(11,12,false,adminEmail, true, "");

            emailServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdateEmail("12", existingConstituent));
            phoneServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdatePhone("12", existingConstituent));
            addressServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdateAddress("12", existingConstituent));
            loginServiceImpl.AssertWasCalled(impl => impl.UpdateAsAdmin(false, existingConstituent.Id));
            mail.AssertWasCalled(mail1 => mail1.Send(email.Address, "Kallivayalil Account Activated", "Your Account has been activated."));
            mail.AssertWasCalled(mail1 => mail1.Send(adminEmail, "Kallivayalil Account Activated", string.Format("Account-{0} has been activated.", email.Address)));

        }


        [Test]
        public void ShouldRejectAConstituentIfNotApproved()
        {
            var mail = MockRepository.GenerateMock<IMail>();
            var repository = MockRepository.GenerateMock<IRegisterationRepository>();
            var constituentRepository = MockRepository.GenerateMock<IConstituentRepository>(null);
            var emailServiceImpl = MockRepository.GenerateMock<IEmailServiceImpl>();
            var  phoneServiceImpl = MockRepository.GenerateMock<IPhoneServiceImpl>();
            var  addressServiceImpl = MockRepository.GenerateMock<IAddressServiceImpl>();
            var loginServiceImpl = MockRepository.GenerateMock<ILoginServiceImpl>();

            var registrationServiceImpl = new RegistrationServiceImpl(repository, constituentRepository, mail, emailServiceImpl, phoneServiceImpl, addressServiceImpl, loginServiceImpl);

            var existingConstituent = new Constituent {Id = 11};
            var newConstituent = new Constituent {Id = 12};
            var email = new Email { Address = "a@b.com" };
            var rejectReason = "Reject";
            var adminEmail = "x@y.com";

            constituentRepository.Stub(repository1 => repository1.Load(11)).Return(existingConstituent);
            constituentRepository.Stub(repository1 => repository1.Load(12)).Return(newConstituent);
            constituentRepository.Stub(repository1 => repository1.Delete(newConstituent.Id));
            emailServiceImpl.Stub(impl => impl.FindEmails(newConstituent.Id.ToString())).Return(new List<Email> {email});

            registrationServiceImpl.RegisterConstituent(11,12,false,adminEmail, false, rejectReason);


            emailServiceImpl.AssertWasCalled(impl => impl.FindEmails(newConstituent.Id.ToString()));
            mail.AssertWasCalled(mail1 => mail1.Send(email.Address, "Kallivayalil Account Activation Failed.", string.Format(@"Dear Ma'am/Sir , {0} The request you placed to activate 
                                        your Kallivayalil account has been reject by the admn team.
                                        {0} The reason is as follows : {1}{0} For any further queries 
                                        contact the admin team.{0} Reagards,{0} Admin Team", "\n", rejectReason)));
            mail.AssertWasCalled(mail1 => mail1.Send(adminEmail, "Kallivayalil Account Registration Rejected.", string.Format(@"Account-{0} has been rejected. Reason : {1}", email.Address,rejectReason)));

        }


        
    }
}
