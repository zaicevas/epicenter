using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.OpenALPR.Responses;

namespace WebApplication1.Services
{
    public class PlateService
    {
        #region
        private const string _shKey = "sk_7f8cafb2b09b7e5185fe9682";
        #endregion
        private const string _platePath = @"C:\Users\ferN\plate_testing\bmw_verygood.jpg";

        public PlateResponse CallCloud(string imgPath)
        {
            Byte[] bytes = File.ReadAllBytes(imgPath);
            string imagebase64 = Convert.ToBase64String(bytes);
            var client = new RestClient("https://api.openalpr.com/v2");
            var request = new RestRequest("recognize_bytes", Method.POST);
            request.AddParameter("secret_key", _shKey, ParameterType.QueryString);
            request.AddParameter("recognize_vehicle", 0, ParameterType.QueryString);
            request.AddParameter("country", "eu", ParameterType.QueryString);
            request.AddParameter("return_image", 0, ParameterType.QueryString);
            request.AddParameter("topn", 10, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(imagebase64);
            System.Diagnostics.Debug.WriteLine(client.BuildUri(request));

            IRestResponse<PlateResponse> response = client.Execute<PlateResponse>(request);
            return response.Data;
        }
    }
}
