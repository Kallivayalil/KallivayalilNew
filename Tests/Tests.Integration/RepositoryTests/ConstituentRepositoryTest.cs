﻿using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ConstituentRepositoryTest
    {
        private Constituent constituent;
        private ConstituentRepository constituentRepository;
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;


        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = new Constituent {Gender = "M", BornOn = DateTime.Today, BranchName = BranchTypeMother.Kallivayalil(), MaritialStatus = 1, IsRegistered = 'N'};
            constituent.Name = ConstituentNameMother.JamesFranklin();
            savedConstituent = testDataHelper.CreateConstituent(constituent);

            constituentRepository = new ConstituentRepository();
        }


        [TearDown]
        public void TearDown()
        {
            testDataHelper.session.Clear();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteLogins();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeleteEducationDetails();
            testDataHelper.HardDeleteOccupations();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldSaveAConstituent()
        {
            var savedConst = constituentRepository.Save(constituent);

            Assert.That(savedConst.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Name.Id, Is.GreaterThan(0));
            constituentRepository.Delete(savedConst);
        }


        [Test]
        public void ShouldUpdateAnExistingConstituent()
        {
            
            savedConstituent.Gender = "F";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Gender, Is.EqualTo("F"));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.Not.EqualTo(savedConstituent.UpdatedDateTime));
            Assert.That(savedConstituent.UpdatedDateTime, Is.Not.Null);
            Assert.That(savedConstituent.UpdatedBy, Is.Not.Null);
        }

        [Test]
        public void ShouldUpdateAnExistingConstituentName()
        {
            savedConstituent.Name.MiddleName = "Einstein";
            var updatedConstituent = constituentRepository.Update(savedConstituent);

            Assert.That(updatedConstituent.Name.MiddleName, Is.EqualTo("Einstein"));
            Assert.That(savedConstituent.Name.UpdatedDateTime, Is.Not.EqualTo(savedConstituent.UpdatedDateTime));

        }

        [Test]
        public void ShouldDeleteAConstituent()
        {
            constituentRepository.Delete(savedConstituent.Id);

            Assert.That(constituentRepository.Exists(savedConstituent), Is.False);
        }

        [Test]
        public void ShouldDeleteCascadeAConstituent()
        {
            var official = EmailMother.Official(savedConstituent);
            official.IsPrimary = true;
            var email = testDataHelper.CreateEmail(official);
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile((savedConstituent)));
            var login = testDataHelper.CreateLogin(new Login {IsAdmin = false,Password = "Pass",Email =email });

            constituentRepository.CascadeDelete(savedConstituent.Id);

            Assert.That(constituentRepository.Exists(savedConstituent), Is.False);
        }


        [Test]
        public void ShouldLoadConstituentForTheGivenId()
        {
            var result = constituentRepository.Load(savedConstituent.Id);

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf(typeof (Constituent)));
            Assert.That(result.Id, Is.EqualTo(savedConstituent.Id));
        }

        [Test]
        public void ShouldLoadAllConstituentsWithBirthdayToday()
        {
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba()));

            var constituents = constituentRepository.LoadAllConstituentsWithBirthdayToday();

            Assert.That(constituents.Count,Is.EqualTo(2));
        }

        [Test]
        public void ShouldSearchConstituentByName()
        {
            var constituentName = ConstituentNameMother.AgnesAlba();
            var savedConst = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(constituentName));

            IList<Constituent> result = constituentRepository.SearchByConstituentName(constituentName.FirstName, constituentName.LastName,constituentName.PreferedName, false);

            Assert.That(result.Count(), Is.EqualTo(1));
        }
    
        
        [Test]
        public void ShouldSearchConstituentByNameMatchAllCriteria()
        {
            var constituentName = ConstituentNameMother.AgnesAlba();
            var savedConst = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(constituentName));

            IList<Constituent> result = constituentRepository.SearchByConstituentName(constituentName.FirstName, constituentName.LastName,string.Empty, true);

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldSearchConstituentByBranch()
        {
            var constituentName = ConstituentNameMother.AgnesAlba();
            var constituentWithName = ConstituentMother.ConstituentWithName(constituentName);
            constituentWithName.BranchName = BranchTypeMother.Anavalaril();
            constituentWithName.HouseName = "xyz";
            var savedConst = testDataHelper.CreateConstituent(constituentWithName);

            IList<Constituent> result = constituentRepository.SearchByConstituentBranch(savedConst.BranchName.Description);

            Assert.That(result.Count(), Is.EqualTo(1));
        }
        
        [Test]
        public void ShouldSearchConstituentByHouseName()
        {
            var constituentName = ConstituentNameMother.AgnesAlba();
            var constituentWithName = ConstituentMother.ConstituentWithName(constituentName);
            constituentWithName.BranchName = BranchTypeMother.Anavalaril();
            constituentWithName.HouseName = "xyz";
            var savedConst = testDataHelper.CreateConstituent(constituentWithName);

            IList<Constituent> result = constituentRepository.SearchByConstituentHouseName("xyz");

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetAllConstituentsForApproval()
        {
            var constituents = constituentRepository.ConstituentsForApproval();
            Assert.That(constituents.Count,Is.EqualTo(0));

            var savedForApproval = constituentRepository.Save(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(), 'A'));

            constituents = constituentRepository.ConstituentsForApproval();
            Assert.That(constituents.Count, Is.EqualTo(1));
            Assert.That(constituents.First().Id, Is.EqualTo(savedForApproval.Id));
        }
    }
}