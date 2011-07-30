using System;
using System.IO;
using System.Net;
using System.Text;

namespace Kallivayalil.Client
{
    public class HttpHelper
    {
        public static T Get<T>(string uriString)
        {
            var response = DoHttpGet(uriString);
            ValidateResponse(response);
            return ExtractResponse<T>(response);
        }

        public static T Post<T>(string uriString, T postData)
        {
            var response = DoHttpPost(uriString, new DataContractHelper().Serialize(postData));
            ValidateResponse(response);
            return ExtractResponse<T>(response);
        }

        public static T Put<T>(string uriString, T putData)
        {
            var response = DoHttpPut(uriString, new DataContractHelper().Serialize(putData));
            ValidateResponse(response);
            return ExtractResponse<T>(response);
        }

        private static void ValidateResponse(HttpWebResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(string.Format("Server Error. Error code : '{0}'. Error Description : {1}", response.StatusCode, response.StatusDescription));
            }
        }

        public static HttpWebResponse DoHttpGet(string uriString)
        {
            var webHeaderCollection = new WebHeaderCollection();
            return DoHttpGet(uriString, webHeaderCollection);
        }

        public static HttpWebResponse DoHttpGet(string uriString, WebHeaderCollection headers)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Headers = headers;
            return ExecuteRequestSwallowingExceptions(request);
        }

        public static HttpWebResponse DoHttpDelete(string uriString)
        {
            var webHeaderCollection = new WebHeaderCollection();
            return DoHttpDelete(uriString, webHeaderCollection);
        }

        public static HttpWebResponse DoHttpDelete(string uriString, WebHeaderCollection headers)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Headers = headers;
            request.Method = "DELETE";
            return ExecuteRequestSwallowingExceptions(request);
        }

        public static HttpWebResponse DoHttpDeleteOverPost(string uriString)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Method = "DELETE"; // So the hmac security will match the server side			
            request.ContentLength = 0;
            request.Method = "POST";
            request.Headers["X-HTTP-Method-Override"] = "DELETE";
            return ExecuteRequestSwallowingExceptions(request);
        }

        public static HttpWebResponse DoHttpPost(string uriString, string postData)
        {
            var webHeaderCollection = new WebHeaderCollection();
            return DoHttpPost(uriString, postData, webHeaderCollection);
        }

        public static HttpWebResponse DoHttpPost(string uriString, string postData, WebHeaderCollection headers)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Headers = headers;
            request.Method = "POST";
            AddXmlBodyDataToRequest(request, postData);
            return ExecuteRequestSwallowingExceptions(request);
        }

        public static HttpWebResponse DoHttpPut(string uriString, string putData)
        {
            var webHeaderCollection = new WebHeaderCollection();
            return DoHttpPut(uriString, putData, webHeaderCollection);
        }

        public static HttpWebResponse DoHttpPut(string uriString, string putData, WebHeaderCollection headers)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Headers = headers;
            request.Method = "PUT";
            AddXmlBodyDataToRequest(request, putData);
            return ExecuteRequestSwallowingExceptions(request);
        }

        public static HttpWebResponse DoHttpPutOverPost(string uriString, string putData)
        {
            var request = (HttpWebRequest) WebRequest.Create(uriString);
            request.Method = "PUT"; // So the hmac security will match the server side
            AddXmlBodyDataToRequest(request, putData);
            request.Method = "POST";
            request.Headers["X-HTTP-Method-Override"] = "PUT";
            return ExecuteRequestSwallowingExceptions(request);
        }

        private static HttpWebResponse ExecuteRequestSwallowingExceptions(WebRequest request)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException wex)
            {
                response = (HttpWebResponse) wex.Response;
            }
            return response;
        }

        public static void AddXmlBodyDataToRequest(WebRequest request, string bodyData)
        {
            request.ContentType = "application/xml";
            var data = Encoding.ASCII.GetBytes(bodyData);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
        }

        public static string ExtractResponseBody(HttpWebResponse response)
        {
            var responseStream = response.GetResponseStream();
            if (responseStream == null)
            {
                throw new Exception("Server Error : The server returned an empty response.");
            }
            return (new StreamReader(responseStream).ReadToEnd());
        }

        public static T ExtractResponse<T>(HttpWebResponse response)
        {
            return new DataContractHelper().Deserialize<T>(ExtractResponseBody(response));
        }
    }
}