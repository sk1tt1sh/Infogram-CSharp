# Infogram-CSharp
SDK For interacting with the infogram API (https://infogr.am/)

Use it exactly like the JAVA SDK as shown here:
https://github.com/infogram/infogram-java-samples/blob/master/src/main/java/net/infogram/example/CreateInfographic.java

THIS LIBRARY USES .NET 4.5+

//Example:
```cs
using Infogram;          
using System.Net.Http; //needed for the HttpResponseMessage object returned by the api

class Program
{                          
  static void Main()            
  {                   
    InfogramAPI api = new InfogramAPI("API_KEY","API_SECRET");
    
    Dictionary<string,string> parameters = new Dictionary<string,string>();
    parameters.Add("theme_id","32");
    parameters.Add("title","Test");
    parameters.Add("content","[{\"text\":\"Hello!\",\"type\":\"h1\"}]");
    
    WriteResponse(api.SendRequest("POST","infographics",parameters));
    
  }
  
  static async void WriteResponse(HttpResponseMessage response)
  {
    Console.WriteLine(await response.Content.ReadAsStringAsync());
  }
}
```
//

-sk1tt1sh
