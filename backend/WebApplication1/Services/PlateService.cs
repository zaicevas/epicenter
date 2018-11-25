using RestSharp;
using System.Collections.Generic;
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
using WebApplication1.Infrastructure.Timestampers.Abstract;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class PlateService
    {
        private readonly string _shKey = AppSettings.Configuration.AlprKey;
        private PlateRepository _plateRepository;
        private readonly ITimestamper<Plate> _timestamper;

        public PlateService(PlateRepository plateRepository, ITimestamper<Plate> timestamper)
        {
            _plateRepository = plateRepository;
            _timestamper = timestamper;
        }

        public async Task<PlateResponse> RecognizeAsync(string base64)
        {
            List<Plate> identifiedPlates = await GetIdentifiedPlatesAsync(base64);
            return GetPlateResponse(identifiedPlates);
        }

        private async Task<List<Plate>> GetIdentifiedPlatesAsync(string base64)
        {
            PlateAPIResponse cloudResponse = await GetPlateAPIResponseAsync(base64);
            cloudResponse.UpdateMatchesPattern(AppSettings.Configuration.PlatePattern);
            List<PlateAPIResult> matchingResults = cloudResponse.Results.Where(result => result.MatchesPattern).ToList();
            List<Plate> identifiedPlates = new List<Plate>();
            matchingResults.ForEach(result =>
            {
                Plate plate = _plateRepository.GetByPlateNumber(result.Plate);
                if (plate != null)
                {
                    _timestamper.Save(plate);
                    identifiedPlates.Add(plate);
                }
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

        private async Task<PlateAPIResponse> GetPlateAPIResponseAsync(string base64)
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

            IRestResponse<PlateAPIResponse> response = await client.ExecuteTaskAsync<PlateAPIResponse>(request);

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
    }
}
