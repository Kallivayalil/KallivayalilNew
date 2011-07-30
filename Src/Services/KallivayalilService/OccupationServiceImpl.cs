using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class OccupationServiceImpl : BaseServiceImpl<Occupation>
    {
        private readonly OccupationRepository repository;
        private readonly ConstituentRepository constituentRepository;

        private void LoadOccupationType(Occupation occupation)
        {
            if (Entity.IsNull(occupation.Type))
            {
                throw new BadRequestException("PhoneType can not be null");
            }

            occupation.Type = repository.Load<OccupationType>(occupation.Type.Id);
        }


        public OccupationServiceImpl(OccupationRepository occupationRepository, ConstituentRepository constituentRepository) : base(occupationRepository)
        {
            repository = occupationRepository;
            this.constituentRepository = constituentRepository;
        }

        public Occupation CreateOccupation(Occupation occupation)
        {
            LoadOccupationType(occupation);
            return repository.Save(occupation);
        }


        public Occupation UpdateOccupation(Occupation occupation)
        {
            LoadOccupationType(occupation);
            return repository.Update(occupation);
        }

        public Occupation FindOccupation(string occupationId)
        {
            return repository.Load(Convert.ToInt32(occupationId));
        }

        public void DeleteOccupation(string occupationId)
        {
            repository.Delete(Convert.ToInt32(occupationId));
        }

        public IList<Occupation> FindOccupations(string constituentId)
        {
            var constituent = constituentRepository.Load(Convert.ToInt32(constituentId));
            return repository.LoadAll(constituent);
        }
    }
}