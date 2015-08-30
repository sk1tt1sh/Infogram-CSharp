using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web;

namespace InfogramAPI
{
    class Helpers
    {
        public static byte[] CalculateHMACSHA1(string data, string key)
        {
            var enc = System.Text.Encoding.UTF8;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(key));
            hmac.Initialize();

            byte[] buffer = enc.GetBytes(data);
            return hmac.ComputeHash(buffer);
        }

        public static string EncodedParamString(List<Parameter> parameters)
        {
            string temp = "";
            foreach(Parameter p in parameters)
            {
                if (temp.Length > 0) temp += "&";

                temp += UpperCaseUrlEncode(p.key) + "=" + UpperCaseUrlEncode(p.value).Replace("+", "%20");
            }
            return temp;
        }

        public static string UpperCaseUrlEncode(string s)
        {
            s = HttpUtility.UrlEncode(s);
            char[] temp = s.ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }
    }
}
