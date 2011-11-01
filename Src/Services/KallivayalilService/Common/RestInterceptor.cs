using System;
using System.Net;
using System.ServiceModel.Web;
using Castle.DynamicProxy;
using Kallivayalil.Client;

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
            catch (BadRequestException e)
            {
                HandleException(e, HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                HandleException(e, HttpStatusCode.InternalServerError);
            }
        }

        private void HandleException(Exception ex, HttpStatusCode responseStatusCode)
        {
            var errorMessageData = new ErrorMessageData
                                       {
                                           Description = ex.Message,
                                       };
            var errorMessagesData = new ErrorMessagesData {errorMessageData};
            throw new WebFaultException<ErrorMessagesData>(errorMessagesData,responseStatusCode);
        }

        private static void AddCacheControlHeader()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
        }
    }
}