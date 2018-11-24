using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Loggers;
using WebApplication1.Infrastructure.Loggers.Abstract;
using WebApplication1.Models;
using WebApplication1.Models.FaceAPI.Responses;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;
using static WebApplication1.Models.Log;

namespace WebApplication1.Services
{
    public class FaceService
    {
        private readonly string _groupID = AppSettings.Configuration.GroupID;
        private readonly PersonRepository _personRepository;
        private readonly FaceAPIService _faceAPIService;

        public FaceService(FaceAPIService faceAPIService, PersonRepository personRepository)
        {
            _faceAPIService = faceAPIService;
            _personRepository = personRepository;
        }

        public async Task<PersonResponse> RecognizeAsync(string base64)
        {
            List<Person> recognizedPersons = await CallFaceAPIAsync(Convert.FromBase64String(base64));
            string message = string.Empty;
            bool recognized = recognizedPersons != null && recognizedPersons.Count > 0;
            if (recognized)
            {
                message = "Found: ";
                recognizedPersons.ForEach(x =>
                {
                    message += x.FullName + " (" + x.Reason + "), ";
                });
                message = message.Substring(0, message.Length - 2);
            }
            else
                message = "No people were recognized.";
            return new PersonResponse { Recognized = recognized, Message = message };
        }

        private async Task<List<Person>> CallFaceAPIAsync(byte[] image)
        {
            ILogger databaseLogger = new DatabaseLogger(new LogRepository(new Mappers.Mapper<Log>()));
            List<Person> recognizedPersons = new List<Person>();
            List<FaceDetectResponse> detectResult = await _faceAPIService.DetectFacesAsync(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach(FaceDetectResponse x in detectResult)
                {
                    string faceID = x.FaceId;
                    if (!string.IsNullOrEmpty(faceID))
                    {
                        List<FaceIdentifyResponse> identifyResult = await _faceAPIService.IdentifyAsync(faceID, _groupID, 1);
                        if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                        {
                            string personId = identifyResult[0].Candidates[0].PersonId;
                            double confidence = identifyResult[0].Candidates[0].Confidence;
                            Person person = _personRepository.GetByFaceAPIID(personId);
                            databaseLogger.Log(LoggableEntity.Person, person.ID);
                            recognizedPersons.Add(person);
                        }
                    }
                };
            }
            return recognizedPersons;
        }
    }
}
