using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class AssociationServiceImpl 
    {
        private readonly AssociationRepository repository;

        public AssociationServiceImpl(AssociationRepository repository) 
        {
            this.repository = repository;
        }

        public Association CreateAssociation(Association association)
        {
            LoadAssociationType(association);
            association.CreateReciprocal();
            return repository.Save(association);
        }

        private void LoadAssociationType(Association association)
        {
            if (Entity.IsNull(association.Type))
            {
                throw new BadRequestException("AssociationType can not be null");
            }
            association.Type = repository.Load<AssociationType>(association.Type.Id);
        }

        public Association UpdateAssociation(Association associaton)
        {
            LoadAssociationType(associaton);
            return repository.Update(associaton);
        }

        public void DeleteAssociation(string id)
        {
            repository.Delete(Convert.ToInt32(id));
        }

        public Association FindAssociation(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }

        public IList<Association> FindAssociations(string constituentId)
        {
            return repository.LoadAll(Convert.ToInt32(constituentId));
        }
    }
}