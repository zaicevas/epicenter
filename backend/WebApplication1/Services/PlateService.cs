using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlateService
    {
        private const string _shKey = "sk_7f8cafb2b09b7e5185fe9682";
        private const string _platePath = @"C:\Users\ferN\Downloads\plates\bmw_NEW.jpg";
        public void RequestCloudService()
        {
            Byte[] bytes = File.ReadAllBytes(_platePath);
            string imagebase64 = Convert.ToBase64String(bytes);

            var client = new RestClient("https://api.openalpr.com/v2");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("recognizeBytes/{id}", Method.POST);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("content", "application/json");

            // execute the request
            //IRestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            RestResponse<Plate> response2 = (RestResponse<Plate>) client.Execute<Plate>(request);
            //var name = response2.Data.Name;
            /*

            // easy async support
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });

            // async with deserialization
            var asyncHandle = client.ExecuteAsync<Person>(request, response => {
                Console.WriteLine(response.Data.Name);
            });

            // abort the request on demand
            asyncHandle.Abort(); */
        }
    }
}
