using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfogramAPI
{
    public class InfogramAPI
    {
        private string apiKey;
        private string apiSecret;

        public InfogramAPI(string apiKey, string apiSecret)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
        }

        public HttpResponseMessage SendRequest(string method,string target,Dictionary<string,string> parameters)
        {
            string baseUrl = Constants.BaseUrl+target;

            List<Parameter> paramList = new List<Parameter>();

            if(parameters != null)
            {
                paramList = new List<Parameter>();
                foreach(KeyValuePair<string,string> kvP in parameters)
                {
                    paramList.Add(new Parameter(kvP.Key, kvP.Value));
                }
            }

            RequestBuilder req = new RequestBuilder(apiKey,apiSecret,baseUrl,method,paramList);

            return req.SendRequest();
        }
    }
}
