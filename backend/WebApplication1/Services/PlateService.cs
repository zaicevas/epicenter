using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.OpenALPR.Responses;
using WebApplication1.Models.Responses;

namespace WebApplication1.Services
{
    public class PlateService
    {
        #region
        private const string _shKey = "sk_7f8cafb2b09b7e5185fe9682";
        #endregion

        public PlateResponse Recognize(string base64)
        {
            PlateAPIResponse cloudResponse = GetPlateResponse(base64);
            
            //TODO: finish this method
            return new PlateResponse();
        }

        public PlateAPIResponse GetPlateResponse(string base64)
        {
            const ParameterType queryString = ParameterType.QueryString;
            RestClient client = new RestClient("https://api.openalpr.com/v2");
            RestRequest request = new RestRequest("recognize_bytes", Method.POST);
            request.AddParameter("secret_key", _shKey, queryString);
            request.AddParameter("recognize_vehicle", 0, queryString);
            request.AddParameter("country", "eu", queryString);
            request.AddParameter("return_image", 0, queryString);
            request.AddParameter("topn", 10, queryString);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(base64);

            IRestResponse<PlateAPIResponse> response = client.Execute<PlateAPIResponse>(request);
            return response.Data;
        }
    }
}
