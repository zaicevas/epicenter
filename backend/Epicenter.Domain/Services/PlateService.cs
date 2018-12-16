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
using static Epicenter.Domain.Models.Abstract.MissingModel;

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

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64, double latitude, double longitude)
        {
            return new List<RecognizedObject>();
            List<RecognizedObject> identifiedPlates = await GetIdentifiedPlatesAsync(base64, latitude, longitude);
            return identifiedPlates;
        }

        private async Task<List<RecognizedObject>> GetIdentifiedPlatesAsync(string base64, double latitude, double longitude)
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
                            MissingModelId = plate.Id,
                            Latitude = latitude,
                            Longitude = longitude
                        };
                    }
                    RecognizedObject recognizedObject = new RecognizedObject()
                    {
                        Id = plate.Id,
                        FirstName = plate.FirstName,
                        LastName = plate.LastName,
                        Reason = plate.Reason,
                        Type = ModelType.Plate,
                        Message = plate.NumberPlate,
                        LastSeen = timestamp.DateTime.GetFormattedDateAndTime()
                    };
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
                            MissingModelId = plate.Id,
                            Latitude = latitude,
                            Longitude = longitude
                        });
                    }
                    recognizedObject.TimestampId = _timestampRepository.GetLatestModelTimestamp(plate.Id).Id;
                    identifiedPlates.Add(recognizedObject);
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

        public void Create(PlateRequest request)
        {
            _plateRepository.Add(new Plate()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Reason = request.Reason ?? SearchReason.Missing,
                BaseImage = request.BaseImage.ConvertToBytesOrDefault(Array.Empty<byte>()),
                NumberPlate = request.NumberPlate
            });
        }

        public void Update(int id, PlateRequest request)
        {
            Plate plate = _plateRepository.GetById(id);
            plate.FirstName = request.FirstName ?? plate.FirstName;
            plate.LastName = request.LastName ?? plate.LastName;
            plate.Reason = request.Reason ?? plate.Reason;
            plate.BaseImage = request.BaseImage.ConvertToBytesOrDefault(plate.BaseImage);
            plate.NumberPlate = request.NumberPlate ?? plate.NumberPlate;
            _plateRepository.Edit(plate);
        }

        public void Delete(int id)
        {
            _plateRepository.Delete(_plateRepository.GetById(id));
        }
    }
}
