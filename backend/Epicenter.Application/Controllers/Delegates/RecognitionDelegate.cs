using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Application.Infrastructure.Utils;

namespace Epicenter.Application.Controllers
{
    public class RecognitionDelegate
    {
        private readonly PlateService _plateService;
        private readonly FaceService _faceService;
        private readonly ILogger _logger;

        public RecognitionDelegate(PlateService plateService, FaceService faceService, ILogger logger)
        {
            _plateService = plateService;
            _faceService = faceService;
            _logger = logger;
        }
        public async Task<RecognizedObject[]> GetRecognitionResultsAsync(string imageBase64)
        {
            _logger.Log(LogType.NORMAL, "Recognition started");
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
                _logger.Log(LogType.ERROR, ex.Message);
                throw;
            }
            RecognizedObject[] responses = plateResponse
                .Concat(personResponse)
                .ToArray();
            _logger.Log(LogType.NORMAL, MessageBuilder.BuildResponseMessage(responses));
            _logger.Log(LogType.NORMAL, "Recognition finished");
            return responses;
        }
    }
}
