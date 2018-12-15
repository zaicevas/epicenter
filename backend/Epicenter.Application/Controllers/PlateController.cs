using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class PlateController : ControllerBase
    {
        private PlateService _plateService;

        public PlateController(PlateService plateService)
        {
            _plateService = plateService;
        }

        [Route("missing/cars")]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetCars()
        {
            return Ok(_plateService.GetAllMissingPlates());
        }

        [Route("car")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult PutCar([FromBody] PlateRequest request)
        {
            try
            {
                _plateService.Create(request);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            return Ok();
        }

        [Route("car/{id}")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult PostCar(int id, [FromBody] PlateRequest request)
        {
            try
            {
                _plateService.Update(id, request);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok();
        }

        [Route("car/{id}")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                _plateService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok();
        }
    }
}