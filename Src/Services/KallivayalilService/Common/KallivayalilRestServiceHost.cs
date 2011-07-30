using System;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using Castle.DynamicProxy;
using Microsoft.ServiceModel.Web;

namespace Kallivayalil.Common
{
    public class KallivayalilRestServiceHost : WebServiceHost
    {
        private readonly Type serviceType;
        private readonly Collection<RequestInterceptor> interceptors = new Collection<RequestInterceptor>();

        public Collection<RequestInterceptor> Interceptors
        {
            get { return interceptors; }
        }

        public KallivayalilRestServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.serviceType = serviceType;
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new KallivayalilRestServiceInterceptorProvider(serviceType, new IInterceptor[] {new RestInterceptor()}));
            base.OnOpening();
            foreach (var ep in Description.Endpoints)
            {
                var binding = new CustomBinding(ep.Binding);
                if (Interceptors.Count > 0)
                {
                    binding.Elements.Insert(0, new RequestInterceptorBindingElement(Interceptors));
                }
                ep.Binding = binding;
            }
        }
    }
}