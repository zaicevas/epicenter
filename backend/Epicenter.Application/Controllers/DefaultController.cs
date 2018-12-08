using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Mvc;

using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Application.Infrastructure.Utils;
using Epicenter.Domain.Models.DTO;


namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RecognitionDelegate _recognizer;

        public DefaultController(RecognitionDelegate recognizer, ILogger logger)
        {
            _logger = logger;
            _recognizer = recognizer;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] string imageBase64)
        {
            _logger.Log(LogType.NORMAL, "POST Request started in PostAsync()");
            List<RecognizedObject> recognizedObjects;
            try
            {
                recognizedObjects = await _recognizer.GetRecognitionResultsAsync(imageBase64);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.ERROR, ex.Message);
                return BadRequest(ex.Message);
            }
            RecognizedObject[] responses = recognizedObjects.ToArray();
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
                return NotFound("Found nothing.");
            }
        }
    }
}
