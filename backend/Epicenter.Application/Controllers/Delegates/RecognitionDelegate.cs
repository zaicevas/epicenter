using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;

using Epicenter.Infrastructure.Debugging.Abstract;

using Epicenter.Application.Infrastructure.Utils;
using Epicenter.Application.Model.DTO.Requests;

namespace Epicenter.Application.Controllers.Delegates
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
        public async Task<RecognizedObject[]> GetRecognitionResultsAsync(RecognitionRequest request)
        {
            _logger.Log(LogType.NORMAL, "Recognition started");
            List<RecognizedObject> plateResponse;
            List<RecognizedObject> personResponse;
            Task<List<RecognizedObject>> getPlateResponseTask = Task.FromResult(new List<RecognizedObject>());
            Task<List<RecognizedObject>> getPersonResponseTask = Task.FromResult(new List<RecognizedObject>());
            try
            {
                if (request.FindPlate)
                    getPlateResponseTask = _plateService.RecognizeAsync(request.ImageBase64);
                if (request.FindFace)
                    getPersonResponseTask = _faceService.RecognizeAsync(request.ImageBase64);

                plateResponse = await getPlateResponseTask;
                personResponse = await getPersonResponseTask;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.ERROR, $"Recognition failed: {ex.Message}");
                throw;
            }
            RecognizedObject[] responses = plateResponse
                .Concat(personResponse)
                .ToArray();
            _logger.Log(LogType.NORMAL, MessageBuilder.BuildResponseMessage(responses));
            _logger.Log(LogType.NORMAL, "Recognition finished successfully");
            return responses;
        }
    }
}
