using System;
using System.Collections;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

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
            return repository.Save(registerationConstituent);
        }

      
       
    }
}