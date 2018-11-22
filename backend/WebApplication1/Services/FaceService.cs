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
        PersonRepository _personRepository = new PersonRepository();

        public async Task<PersonResponse> RecognizeAsync(string base64)
        {
            List<Person> recognizedPersons = await CallFaceAPI(Convert.FromBase64String(base64));
            string message;
            bool recognized = (recognizedPersons != null && recognizedPersons.Count > 0) ? true : false;
            if (recognized)
            {
                message = "Found: ";
                foreach(Person person in recognizedPersons)
                {
                    message += person.FullName + ", ";
                }
            }
            return new PersonResponse { Recognized = recognized };
        }

        private async Task<List<Person>> CallFaceAPI(byte[] image)
        {
            List<Person> recognizedPersons = new List<Person>();
            List<FaceDetectResponse> detectResult = await FaceAPIService.DetectFaces(image);
            if (detectResult != null && detectResult.Count > 0)
            {
                foreach (FaceDetectResponse detectedFace in detectResult)
                {
                    string faceID = detectedFace.FaceId;
                    if (!string.IsNullOrEmpty(faceID))
                    {
                        List<FaceIdentifyResponse> identifyResult = await FaceAPIService.Identify(faceID, "g1", 1);
                        if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                        {
                            string personId = identifyResult[0].Candidates[0].PersonId;
                            double confidence = identifyResult[0].Candidates[0].Confidence;
                            FaceAPIPersonResponse person = await FaceAPIService.GetPerson("g1", personId);
                            recognizedPersons.Add(_personRepository.GetByFaceAPIID(personId));
                        }
                    }
                }
            }
            return recognizedPersons;
        }
    }
}
