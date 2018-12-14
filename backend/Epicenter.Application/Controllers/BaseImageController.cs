using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Epicenter.Application.Controllers
{
    [Route("api/missingmodels/baseimages")]
    [ApiController]
    public class BaseImageController : ControllerBase
    {
        private readonly BaseImageService _baseImageService;

        public BaseImageController(BaseImageService baseImageService)
        {
            _baseImageService = baseImageService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            List<MissingModelBaseImage> missingModelsBaseImages;
            try
            {
                missingModelsBaseImages = _baseImageService.GetAllBaseImages();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(missingModelsBaseImages.ToArray());
        }
    }
}
