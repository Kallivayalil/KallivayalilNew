using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class EducationDetailServiceImpl
    {
        private readonly EducationDetailRepository repository;
        private readonly ConstituentRepository constituentRepository;


        private void LoadEducationType(EducationDetail educationDetail)
        {
            if (Entity.IsNull(educationDetail.Type))
            {
                throw new BadRequestException("EmailType can not be null");
            }

            educationDetail.Type = repository.Load<EducationType>(educationDetail.Type.Id);
        }

        public EducationDetailServiceImpl()
        {
            repository = new EducationDetailRepository();
            constituentRepository = new ConstituentRepository();
        }

        public EducationDetail CreateEducationDetail(EducationDetail educationDetail)
        {
            LoadEducationType(educationDetail);
            return repository.Save(educationDetail);
        }


        public EducationDetail UpdateEducationDetail(EducationDetail educationDetail)
        {
            LoadEducationType(educationDetail);
            return repository.Update(educationDetail);
        }

        public EducationDetail FindEducationDetail(string educationDetailId)
        {
            return repository.Load(Convert.ToInt32(educationDetailId));
        }

        public void DeleteEducationDetail(string educationDetailId)
        {
            repository.Delete(Convert.ToInt32(educationDetailId));
        }

        public IList<EducationDetail> FindEducationDetails(string constituentId)
        {
            var constituent = constituentRepository.Load(Convert.ToInt32(constituentId));
            return repository.LoadAll(constituent);
        }
    }
}