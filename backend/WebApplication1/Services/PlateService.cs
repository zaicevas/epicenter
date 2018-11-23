using RestSharp;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using WebApplication1.Infrastructure.Utils;
using WebApplication1.Models;
using WebApplication1.Models.OpenALPR.Responses;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;
using static WebApplication1.Models.Abstract.MissingModel;
using WebApplication1.Infrastructure.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplication1.Services
{
    public class PlateService
    {
        private readonly string _shKey = AppSettings.Configuration.AlprKey;
        private PlateRepository _plateRepository;

        public PlateService(PlateRepository plateRepository)
        {
            _plateRepository = plateRepository;
        }

        public PlateResponse Recognize(string base64)
        {
            List<Plate> identifiedPlates = GetIdentifiedPlates(base64);
            return GetPlateResponse(identifiedPlates);
        }

        private PlateAPIResponse GetPlateResponse(string base64)
        {
            const ParameterType queryString = ParameterType.QueryString;
            RestClient client = new RestClient(AppSettings.Configuration.PlateAPIEndpoint);
            RestRequest request = new RestRequest("recognize_bytes", Method.POST);
            request.AddParameter("secret_key", _shKey, queryString);
            request.AddParameter("recognize_vehicle", 0, queryString);
            request.AddParameter("country", "eu", queryString);
            request.AddParameter("return_image", 0, queryString);
            request.AddParameter("topn", 10, queryString);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(base64);

            IRestResponse<PlateAPIResponse> response = client.Execute<PlateAPIResponse>(request);
            if (!response.IsSuccessful)
            {
                ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content, new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                });
                throw new HttpException(errorResponse.ErrorCode, errorResponse.Error);
            }
            return response.Data;
        }

        private List<Plate> GetIdentifiedPlates(string base64)
        {
            PlateAPIResponse cloudResponse = GetPlateResponse(base64);
            cloudResponse.UpdateMatchesPattern(AppSettings.Configuration.PlatePattern);
            List<PlateAPIResult> matchingResults = cloudResponse.Results.Where(result => result.MatchesPattern).ToList();
            List<Plate> identifiedPlates = new List<Plate>();
            matchingResults.ForEach(result =>
            {
                Plate plate = _plateRepository.GetByPlateNumber(result.Plate);
                if (plate != null)
                    identifiedPlates.Add(plate);
            });
            return identifiedPlates;
        }

        private PlateResponse GetPlateResponse(List<Plate> identifiedPlates)
        {
            string message = "";
            Dictionary<SearchReason, string> dictionary = SearchReasonMap.reasonDictionary;
            if (identifiedPlates.Count == 0)
            {
                return new PlateResponse()
                {
                    Recognized = false,
                    Message = "No plate has been recognized"
                };
            }
            identifiedPlates.ForEach(plate => message += $"{plate.NumberPlate} is {dictionary[plate.Reason]}\n");
            return new PlateResponse()
            {
                Recognized = true,
                Message = message
            };
        }
    }
}
