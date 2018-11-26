using RestSharp;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Models.OpenALPR.Responses;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;
using WebApplication1.Infrastructure.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApplication1.Infrastructure.Timestampers.Abstract;
using System.Threading.Tasks;
using System;
using WebApplication1.Infrastructure.Extensions;

namespace WebApplication1.Services
{
    public class PlateService
    {
        private readonly string _shKey = AppSettings.Configuration.AlprKey;
        private PlateRepository _plateRepository;
        private TimestampRepository _timestampRepository;
        private readonly ITimestamper<Plate> _timestamper;

        public PlateService(PlateRepository plateRepository, TimestampRepository timestampRepository, ITimestamper<Plate> timestamper)
        {
            _plateRepository = plateRepository;
            _timestampRepository = timestampRepository;
            _timestamper = timestamper;
        }

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64)
        {
            List<RecognizedObject> identifiedPlates = await GetIdentifiedPlatesAsync(base64);
            return identifiedPlates;
        }

        private async Task<List<RecognizedObject>> GetIdentifiedPlatesAsync(string base64)
        {
            PlateAPIResponse cloudResponse = await GetPlateAPIResponseAsync(base64);
            cloudResponse.UpdateMatchesPattern(AppSettings.Configuration.PlatePattern);
            List<PlateAPIResult> matchingResults = cloudResponse.Results.Where(result => result.MatchesPattern).ToList();
            List<RecognizedObject> identifiedPlates = new List<RecognizedObject>();
            matchingResults.ForEach(matching =>
            {
                Plate plate = _plateRepository.GetByPlateNumber(matching.Plate);
                if (plate != null)
                {
                    Timestamp timestamp = _timestampRepository.GetLatestModelTimestamp<Plate>(plate.ID);
                    if (timestamp == null || timestamp.DateAndTime == null)
                    {
                        timestamp = new Timestamp()
                        {
                            DateAndTime = DateTime.Now.GetFormattedDateAndTime(),
                            PlateID = plate.ID
                        };
                    }
                    identifiedPlates.Add(new RecognizedObject()
                    {
                        FirstName = plate.FirstName,
                        LastName = plate.LastName,
                        Reason = plate.Reason,
                        Type = "Plate",
                        Message = plate.NumberPlate,
                        LastSeen = timestamp.DateTime
                    });
                    _timestamper.Save(plate, DateTime.Now);
                }
            });
            return identifiedPlates;
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