using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure.Exceptions;
using WebApplication1.Models.Responses;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly PlateService _plateService;
        private readonly FaceService _faceService;

        public DefaultController(PlateService plateService, FaceService faceService)
        {
            _plateService = plateService;
            _faceService = faceService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            try
            {
                Task<PlateResponse> getPlateResponseTask = _plateService.RecognizeAsync(value);
                Task<PersonResponse> getPersonResponseTask = _faceService.RecognizeAsync(value);
                PlateResponse plateResponse = await getPlateResponseTask;
                PersonResponse personResponse = await getPersonResponseTask;
                if (plateResponse.Recognized || personResponse.Recognized)
                    return Ok(plateResponse.Message + "\n" + personResponse.Message);
                return NotFound("Didn't find anything.");
            }
            catch(HttpException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
