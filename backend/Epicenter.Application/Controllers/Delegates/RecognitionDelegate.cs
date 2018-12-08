using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epicenter.Application.Controllers
{
    public class RecognitionDelegate
    {
        private readonly PlateService _plateService;
        private readonly FaceService _faceService;

        public RecognitionDelegate(PlateService plateService, FaceService faceService)
        {
            _plateService = plateService;
            _faceService = faceService;
        }
        public async Task<List<RecognizedObject>> GetRecognitionResultsAsync(string imageBase64)
        {
            List<RecognizedObject> plateResponse;
            List<RecognizedObject> personResponse;
            try
            {
                Task<List<RecognizedObject>> getPlateResponseTask = _plateService.RecognizeAsync(imageBase64);
                Task<List<RecognizedObject>> getPersonResponseTask = _faceService.RecognizeAsync(imageBase64);
                plateResponse = await getPlateResponseTask;
                personResponse = await getPersonResponseTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<RecognizedObject> responses = plateResponse
                .Concat(personResponse)
                .ToList();
            return responses;
        }
    }
}
