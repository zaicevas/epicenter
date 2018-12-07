﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Epicenter.Application.Infrastructure.Utils;
using Epicenter.Domain.Services;
using Epicenter.Domain.Models.Responses;
using Epicenter.Debugging.Abstract;
using Epicenter.Exceptions;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly PlateService _plateService;
        private readonly FaceService _faceService;
        private readonly ILogger _logger;

        public DefaultController(PlateService plateService, FaceService faceService, ILogger logger)
        {
            _plateService = plateService;
            _faceService = faceService;
            _logger = logger;
        }

        public object LogType { get; private set; }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] string imageBase64)
        {
            _logger.Log(LogType.NORMAL, "POST Request started in PostAsync()");
            Task<List<RecognizedObject>> getPlateResponseTask;
            Task<List<RecognizedObject>> getPersonResponseTask;
            List<RecognizedObject> plateResponse;
            List<RecognizedObject> personResponse;
            try
            {
                getPlateResponseTask = _plateService.RecognizeAsync(imageBase64);
                getPersonResponseTask = _faceService.RecognizeAsync(imageBase64);
                plateResponse = await getPlateResponseTask;
                personResponse = await getPersonResponseTask;
            }
            catch(HttpException ex)
            {
                _logger.Log(LogType.ERROR, ex.Message);
                return BadRequest(ex.Message);
            }
            RecognizedObject[] responses = plateResponse.Concat(personResponse).ToArray();
            if (responses.Length > 0)
            {
                _logger.Log(LogType.NORMAL, MessageBuilder.BuildResponseMessage(responses));
                _logger.Log(LogType.NORMAL, "Request finished successfully");
                return Ok(responses);
            }
            else
            {
                _logger.Log(LogType.NORMAL, "Found: None");
                _logger.Log(LogType.NORMAL, "Request finished successfully");
                return NotFound("Didn't find anything.");
            }
        }
    }
}
