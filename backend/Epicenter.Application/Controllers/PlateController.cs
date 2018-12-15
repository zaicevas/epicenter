using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}