using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.FaceAPI.Responses;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class FaceService
    {
        private string _groupID = AppSettings.Configuration.GroupID;
        private PersonRepository _personRepository = new PersonRepository();
        private FaceAPIService _faceAPIService = new FaceAPIService();

        public async Task<PersonResponse> RecognizeAsync(string base64)
        {
            List<Person> recognizedPersons = await CallFaceAPI(Convert.FromBase64String(base64));
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
            return new PersonResponse { Recognized = recognized, Message = message };
        }

        private async Task<List<Person>> CallFaceAPI(byte[] image)
        {
            List<Person> recognizedPersons = new List<Person>();
            List<FaceDetectResponse> detectResult = await _faceAPIService.DetectFaces(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach(FaceDetectResponse x in detectResult)
                {
                    string faceID = x.FaceId;
                    if (!string.IsNullOrEmpty(faceID))
                    {
                        List<FaceIdentifyResponse> identifyResult = await _faceAPIService.Identify(faceID, _groupID, 1);
                        if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                        {
                            string personId = identifyResult[0].Candidates[0].PersonId;
                            double confidence = identifyResult[0].Candidates[0].Confidence;
                            FaceAPIPersonResponse person = await _faceAPIService.GetPerson(_groupID, personId);
                            recognizedPersons.Add(_personRepository.GetByFaceAPIID(personId));
                        }
                    }
                };
            }
            return recognizedPersons;
        }
    }
}
