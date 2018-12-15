using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services.DTO.Plate.Responses;
using Epicenter.Infrastructure;
using Epicenter.Infrastructure.Extensions;
using Epicenter.Infrastructure.Exceptions;

namespace Epicenter.Domain.Services
{
    public class PlateService
    {
        private readonly string _shKey = AppSettings.Configuration.AlprKey;
        private IPlateRepository _plateRepository;
        private ITimestampRepository _timestampRepository;

        public PlateService(IPlateRepository plateRepository, ITimestampRepository timestampRepository)
        {
            _plateRepository = plateRepository;
            _timestampRepository = timestampRepository;
        }

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64)
        {
            return new List<RecognizedObject>();
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
                    Timestamp timestamp = _timestampRepository.GetLatestModelTimestamp(plate.Id);
                    bool seenBefore = true;
                    if (timestamp == null || timestamp.DateAndTime == null)
                    {
                        seenBefore = false;
                        timestamp = new Timestamp()
                        {
                            DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime(),
                            MissingModelId = plate.Id
                        };
                    }
                    identifiedPlates.Add(new RecognizedObject()
                    {
                        Id = plate.Id,
                        FirstName = plate.FirstName,
                        LastName = plate.LastName,
                        Reason = plate.Reason,
                        Type = ModelType.Plate,
                        Message = plate.NumberPlate,
                        LastSeen = timestamp.DateTime.GetFormattedDateAndTime()
                    });
                    if (seenBefore && timestamp.DateTime > DateTime.UtcNow.ToUTC2().AddMinutes(-1))
                    {
                        timestamp.DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime();
                        _timestampRepository.Edit(timestamp);
                    }
                    else
                    {
                        _timestampRepository.Add(new Timestamp()
                        {
                            DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime(),
                            MissingModelId = plate.Id
                        });
                    }
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

        public List<Plate> GetAllMissingPlates()
        {
            return new List<Plate>(_plateRepository.GetAll());
        }
    }
}
