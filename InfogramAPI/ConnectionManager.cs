using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfogramAPI
{
    class ConnectionManager
    {
        public static HttpResponseMessage SendRequest(string baseUrl,string requestMethod,List<Parameter> parameters)
        {
            switch(requestMethod)
            {
                case "GET":
                    return SendGetRequest(baseUrl, parameters);
                case "POST":
                    return SendPostPutRequest(requestMethod, baseUrl, parameters);
                case "PUT":
                    return SendPostPutRequest(requestMethod, baseUrl, parameters);
                case "DELETE":
                    return SendDeleteRequest(baseUrl, parameters);
                default:
                    throw new ArgumentNullException();
            }
        }

        public static HttpResponseMessage SendGetRequest(string baseUrl, List<Parameter> parameters)
        {
            string url = baseUrl;

            url += "?" + Helpers.EncodedParamString(parameters);

            System.Diagnostics.Debug.WriteLine("USING URL: " + url);

            HttpClient client = new HttpClient();

            return client.GetAsync(url).Result;
        }

        public static HttpResponseMessage SendPostPutRequest(string requestMethod,string baseUrl,List<Parameter> parameters)
        {
            HttpClient client = new HttpClient();
            
            Dictionary<string,string> content = new Dictionary<string,string>();
            
            foreach(Parameter p in parameters)
            {
                System.Diagnostics.Debug.WriteLine(p.key + " " + p.value);
                content.Add(p.key,p.value); 
            }

            var postData = new FormUrlEncodedContent(content);

            if (requestMethod == "POST")
                return client.PostAsync(baseUrl, postData).Result;
            else if (requestMethod == "PUT")
                return client.PutAsync(baseUrl, postData).Result;
            else
                return new HttpResponseMessage();
        }

        public static HttpResponseMessage SendDeleteRequest(string baseUrl,List<Parameter> parameters)
        {
            string url = baseUrl;
            url += "?" + Helpers.EncodedParamString(parameters);
            HttpClient client = new HttpClient();

            return client.DeleteAsync(url).Result;
        }
    }
}
