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
            constituentRepository.Stub(repository1 => repository1.Load(11)).Return(existingConstituent);
            constituentRepository.Stub(repository1 => repository1.Load(12)).Return(newConstituent);
            constituentRepository.Stub(repository1 => repository1.Update(existingConstituent)).Return(newConstituent);
            constituentRepository.Stub(repository1 => repository1.Delete(newConstituent.Id));

            emailServiceImpl.Stub(impl => impl.SetConstituentAndUpdateEmail("12", existingConstituent));
            phoneServiceImpl.Stub(impl => impl.SetConstituentAndUpdatePhone("12", existingConstituent));
            addressServiceImpl.Stub(impl => impl.SetConstituentAndUpdateAddress("12", existingConstituent));
            loginServiceImpl.Stub(impl => impl.UpdateAsAdmin(false,existingConstituent.Id));

            registrationServiceImpl.RegisterConstituent(11,12,false,"x@y.com");

            emailServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdateEmail("12", existingConstituent));
            phoneServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdatePhone("12", existingConstituent));
            addressServiceImpl.AssertWasCalled(impl => impl.SetConstituentAndUpdateAddress("12", existingConstituent));


        }
    }
}
