using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Kallivayalil.Common
{
    public class RestServiceFactory : WebServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return CreateServiceHost(Type.GetType(constructorString), baseAddresses);
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceHost = new KallivayalilRestServiceHost(serviceType, baseAddresses);
            return serviceHost;
        }
    }
}