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
        private readonly string _groupID = AppSettings.Configuration.GroupID;
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

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64)
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
            List<Person> result = await CallFaceAPIAsync(imgBytes);
            List<RecognizedObject> recognizedPersons = new List<RecognizedObject>();
            result.ForEach(person =>
            {
                Timestamp timestamp = _timestampRepository.GetLatestModelTimestamp<Person>(person.ID);
                if (timestamp == null || timestamp.DateAndTime == null)
                {
                    timestamp = new Timestamp()
                    {
                        DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime(),
                        PersonID = person.ID
                    };
                }
                recognizedPersons.Add(new RecognizedObject()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Reason = person.Reason,
                    Type = ModelType.Person,
                    Message = "no description",
                    LastSeen = timestamp.DateTime.GetFormattedDateAndTime()
                });
                _timestampRepository.Add(new Timestamp()
                {
                    DateAndTime = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime(),
                    PersonID = person.ID
                });
            });
            return recognizedPersons;
        }

        private async Task<List<Person>> CallFaceAPIAsync(byte[] image)
        {
            List<Person> recognizedPersons = new List<Person>();
            List<DetectResponse> detectResult = await _faceAPIService.DetectFacesAsync(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach (DetectResponse face in detectResult)
                {
                    string faceID = face.FaceId;
                    if (!string.IsNullOrEmpty(faceID))
                    {
                        List<IdentifyResponse> identifyResult = await _faceAPIService.IdentifyAsync(faceID, _groupID, 1);
                        if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                        {
                            string personId = identifyResult[0].Candidates[0].PersonId;
                            Person person = _personRepository.GetByFaceAPIID(personId);
                            recognizedPersons.Add(person);
                        }
                    }
                };
            }
            return recognizedPersons;
        }
    }
}
