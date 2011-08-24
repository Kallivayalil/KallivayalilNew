using System;
using System.Collections;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;

namespace Kallivayalil
{
    public class RegistrationServiceImpl
    {
        private readonly RegisterationRepository repository;


        public RegistrationServiceImpl(RegisterationRepository repository)
        {
            this.repository = repository;
        }

       
        public RegisterationConstituent CreateRegistrationConstituent(RegisterationConstituent registerationConstituent)
        {
            var registrationConstituent = repository.Save(registerationConstituent);

            
            return registrationConstituent;
        }
    }
}