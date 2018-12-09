using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Mvc;

using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Application.DTO.Requests;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] RecognitionRequest request)
        {
            _logger.Log(LogType.NORMAL, "PostAsync request started");
            RecognizedObject[] responses;
            try
            {
                responses = await _recognizer.GetRecognitionResultsAsync(request);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.NORMAL, "PostAsync returned NotFound");
                return NotFound(new { Error = ex.Message });
            }
            _logger.Log(LogType.NORMAL, "PostAsync returned Ok");
            return Ok(responses);
        }
    }
}
