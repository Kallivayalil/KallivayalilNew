using System;
using System.Net;
using System.ServiceModel.Web;
using Castle.DynamicProxy;

namespace Kallivayalil.Common
{
    public class RestInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                AddCacheControlHeader();
                invocation.Proceed();
            }
            catch (NotFoundException e)
            {
                HandleException(e, HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                HandleException(e, HttpStatusCode.InternalServerError);
            }
        }

        private void HandleException(Exception ex, HttpStatusCode responseStatusCode)
        {
            throw new WebFaultException(responseStatusCode);
        }

        private static void AddCacheControlHeader()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
        }
    }
}