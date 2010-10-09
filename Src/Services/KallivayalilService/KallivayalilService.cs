using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class KallivayalilService : IKallivayalilService
    {
        private readonly ConstituentServiceImpl constituentServiceImpl;
        private readonly AutoDataContractMapper mapper;

        public KallivayalilService()
        {
            constituentServiceImpl = new ConstituentServiceImpl();
            mapper = new AutoDataContractMapper();
        }


        public ConstituentData GetConstituent(string id)
        {
            var constituent = constituentServiceImpl.FindConstituent(id);
            var constituentData = new ConstituentData();
            if (constituent == null)
                return null;
            mapper.Map(constituent, constituentData);
            return constituentData;
        }

        public void DeleteConstituent(string id)
        {
            constituentServiceImpl.DeleteConstituent(id);
        }

        public ConstituentData CreateConstituent(ConstituentData constituentData)
        {
            var constituent = new Constituent();
            mapper.Map(constituentData, constituent);
            Constituent savedConstituent = constituentServiceImpl.CreateConstituent(constituent);
            var savedConstituentData = new ConstituentData();
            mapper.Map(savedConstituent,savedConstituentData);
            return savedConstituentData;
        }

        public ConstituentData UpdateConstituent(string id, ConstituentData constituentData)
        {
            var constituent=new Constituent();
            mapper.Map(constituentData,constituent);
            Constituent updatedConstituent = constituentServiceImpl.UpdateConstituent(id, constituent);
            var updateConstiuentData = new ConstituentData();
            mapper.Map(updatedConstituent,updateConstiuentData);
            return updateConstiuentData;
        }
    }
}