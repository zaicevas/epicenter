using Epicenter.Domain.Models;
using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services.DTO.Face.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epicenter.Domain.Abstract;
using Epicenter.Infrastructure;
using Epicenter.Infrastructure.Extensions;
using Epicenter.Infrastructure.Debugging.Abstract;

namespace Epicenter.Domain.Services
{
    public class FaceService
    {
        private readonly string _groupId = AppSettings.Configuration.GroupId;
        private readonly IPersonRepository _personRepository;
        private readonly ITimestampRepository _timestampRepository;
        private readonly FaceAPIService _faceAPIService;
        private readonly ILogger _logger;

        public FaceService(FaceAPIService faceAPIService, IPersonRepository personRepository, ITimestampRepository timestampRepository, ILogger logger)
        {
            _faceAPIService = faceAPIService;
            _personRepository = personRepository;
            _timestampRepository = timestampRepository;
            _logger = logger;
        }

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64, double latitude, double longitude)
        {
            byte[] imgBytes;
            try
            {
                imgBytes = Convert.FromBase64String(base64);
            }
            catch
            {
                throw;
            }
            List<PersonWithSmile> result = await CallFaceAPIAsync(imgBytes);
            List<RecognizedObject> recognizedPersons = new List<RecognizedObject>();
            result.ForEach(personWithSmile =>
            {
                Timestamp timestamp = _timestampRepository.GetLatestModelTimestamp(personWithSmile.Person.Id);
                bool seenBefore = true;
                if (timestamp == null || timestamp.DateAndTime == null)
                {
                    seenBefore = false;
                    timestamp = new Timestamp()
                    {
                        DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime(),
                        MissingModelId = personWithSmile.Person.Id,
                        Latitude = latitude,
                        Longitude = longitude
                    };
                }
                recognizedPersons.Add(new RecognizedObject()
                {
                    Id = personWithSmile.Person.Id,
                    FirstName = personWithSmile.Person.FirstName,
                    LastName = personWithSmile.Person.LastName,
                    Reason = personWithSmile.Person.Reason,
                    Type = ModelType.Person,
                    Message = "no description",
                    Smile = personWithSmile.Smile,
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
                        MissingModelId = personWithSmile.Person.Id,
                        Latitude = latitude,
                        Longitude = longitude
                    });
                }
            });
            return recognizedPersons;
        }

        private async Task<List<PersonWithSmile>> CallFaceAPIAsync(byte[] image)
        {
            List<PersonWithSmile> recognizedPersons = new List<PersonWithSmile>();
            List<DetectResponse> detectResult = await _faceAPIService.DetectFacesAsync(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach (DetectResponse face in detectResult)
                {
                    string faceId = face.FaceId;
                    if (!string.IsNullOrEmpty(faceId))
                    {
                        List<IdentifyResponse> identifyResult = await _faceAPIService.IdentifyAsync(faceId, _groupId, 1);
                        if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                        {
                            string personId = identifyResult[0].Candidates[0].PersonId;
                            Person person = _personRepository.GetByFaceAPIId(personId);
                            recognizedPersons.Add(new PersonWithSmile()
                            {
                                Person = person,
                                Smile = face.FaceAttributes.Smile
                            });
                        }
                    }
                };
            }
            return recognizedPersons;
        }
    }
}
