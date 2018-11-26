using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.FaceAPI.Responses;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class FaceService
    {
        private readonly string _groupID = AppSettings.Configuration.GroupID;
        private readonly PersonRepository _personRepository;
        private readonly TimestampRepository _timestampRepository;
        private readonly FaceAPIService _faceAPIService;

        public FaceService(FaceAPIService faceAPIService, PersonRepository personRepository, TimestampRepository timestampRepository)
        {
            _faceAPIService = faceAPIService;
            _personRepository = personRepository;
            _timestampRepository = timestampRepository;
        }

        public async Task<List<RecognizedObject>> RecognizeAsync(string base64)
        {
            List<Person> result = await CallFaceAPIAsync(Convert.FromBase64String(base64));
            List<RecognizedObject> recognizedPersons = new List<RecognizedObject>();
            result.ForEach(person =>
            {
                Timestamp timestamp = _timestampRepository.GetLatestModelTimestamp<Person>(person.ID);
                if (timestamp == null || timestamp.DateAndTime == null)
                {
                    timestamp = new Timestamp()
                    {
                        DateAndTime = DateTime.Now.GetFormattedDateAndTime(),
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
                    DateAndTime = DateTime.Now.GetFormattedDateAndTime(),
                    PersonID = person.ID
                });
            });
            return recognizedPersons;
        }

        private async Task<List<Person>> CallFaceAPIAsync(byte[] image)
        {
            List<Person> recognizedPersons = new List<Person>();
            List<FaceDetectResponse> detectResult = await _faceAPIService.DetectFacesAsync(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach (FaceDetectResponse face in detectResult)
                {
                    string faceID = face.FaceId;
                    if (!string.IsNullOrEmpty(faceID))
                    {
                        List<FaceIdentifyResponse> identifyResult = await _faceAPIService.IdentifyAsync(faceID, _groupID, 1);
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