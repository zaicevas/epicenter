using Epicenter.Domain.Models;
using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class BaseImageController : ControllerBase
    {
        private readonly BaseImageService _baseImageService;

        public BaseImageController(BaseImageService baseImageService)
        {
            _baseImageService = baseImageService;
        }

        [Route("missingmodels/baseimages")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetMissingModelsImages()
        {
            List<MissingModelBaseImage> missingModelsBaseImages;
            try
            {
                missingModelsBaseImages = _baseImageService.GetAllSeenBaseImages();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(missingModelsBaseImages.ToArray());
        }

        [Route("persons/baseimages")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetPersonsImages()
        {
            List<MissingModelBaseImage> missingModelsBaseImages;
            try
            {
                missingModelsBaseImages = _baseImageService.GetSeenBaseImages<Person>();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(missingModelsBaseImages.ToArray());
        }

        [Route("cars/baseimages")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCarsImages()
        {
            List<MissingModelBaseImage> missingModelsBaseImages;
            try
            {
                missingModelsBaseImages = _baseImageService.GetSeenBaseImages<Plate>();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(missingModelsBaseImages.ToArray());
        }
    }
}
