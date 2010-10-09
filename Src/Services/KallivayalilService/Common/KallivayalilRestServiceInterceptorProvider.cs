using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Castle.DynamicProxy;

namespace Kallivayalil.Common
{
    public class KallivayalilRestServiceInterceptorProvider : IInstanceProvider, IServiceBehavior
    {
        private readonly Type serviceType;
        private readonly IInterceptor[] interceptors;

        public KallivayalilRestServiceInterceptorProvider(Type serviceType, IInterceptor[] interceptors)
        {
            this.serviceType = serviceType;
            this.interceptors = interceptors;
        }

        public IInterceptor[] Interceptors
        {
            get { return interceptors; }
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var proxyGenerator = new ProxyGenerator();
            return proxyGenerator.CreateClassProxy(serviceType, Interceptors);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher == null) continue;

                foreach (var endpoint in channelDispatcher.Endpoints)
                {
                    endpoint.DispatchRuntime.InstanceProvider = this;
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}