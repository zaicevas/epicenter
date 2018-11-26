using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure.Debugging.Abstract;
using WebApplication1.Infrastructure.Exceptions;
using WebApplication1.Models.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
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

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] string imageBase64)
        {
            _logger.Log(LogType.NORMAL, "POST Request started in PostAsync()\n");
            try
            {
                Task<PlateResponse> getPlateResponseTask = _plateService.RecognizeAsync(imageBase64);
                Task<PersonResponse> getPersonResponseTask = _faceService.RecognizeAsync(imageBase64);
                PlateResponse plateResponse = await getPlateResponseTask;
                PersonResponse personResponse = await getPersonResponseTask;
                _logger.Log(LogType.NORMAL, "Request finished sucessfully\n");
                if (plateResponse.Recognized || personResponse.Recognized)
                    return Ok(plateResponse.Message + "\n" + personResponse.Message);
                return NotFound("Didn't find anything.");
            }
            catch(HttpException ex)
            {
                _logger.Log(LogType.ERROR, $"{ex.Message}\n");
                return BadRequest(ex.Message);
            }
        }
    }
}
