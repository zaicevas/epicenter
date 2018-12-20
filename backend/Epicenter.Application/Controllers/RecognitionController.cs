using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Mvc;

using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Domain.Models.DTO;
using Epicenter.Application.Model.DTO.Requests;
using Epicenter.Application.Controllers.Delegates;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class RecognitionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RecognitionDelegate _recognizer;

        public RecognitionController(RecognitionDelegate recognizer, ILogger logger)
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
