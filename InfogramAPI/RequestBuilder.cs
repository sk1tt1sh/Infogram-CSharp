using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Http;

namespace Infogram
{
    class RequestBuilder
    {
        private string apiKey, apiSecret, baseUrl, requestMethod;
        private List<Parameter> parameters;

        public RequestBuilder(string apiKey,string apiSecret,string baseUrl,string requestMethod,List<Parameter> parameters)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.baseUrl = baseUrl;
            this.requestMethod = requestMethod;
            this.parameters = parameters;

            this.parameters.Add(new Parameter("api_key", this.apiKey));
            string signature = ComputeSignature(this.baseUrl, this.requestMethod, this.parameters);
            this.parameters.Add(new Parameter("api_sig", signature));
        }

        private string ComputeSignature(string baseUrl, string requestMethod, List<Parameter> parameters)
        {
            string sigBase = Helpers.UpperCaseUrlEncode(requestMethod) + "&" + Helpers.UpperCaseUrlEncode(baseUrl);
            parameters.Sort((o1,o2)=>o1.key.CompareTo(o2.key));

            string paramString = Helpers.EncodedParamString(parameters);

            sigBase += "&" + Helpers.UpperCaseUrlEncode(paramString);

            byte[] sigBaseHash = Helpers.CalculateHMACSHA1(sigBase, apiSecret);

            return Convert.ToBase64String(sigBaseHash);
        }

        public HttpResponseMessage SendRequest()
        {
            return ConnectionManager.SendRequest(baseUrl, requestMethod, parameters);
        }

        
    }
}
