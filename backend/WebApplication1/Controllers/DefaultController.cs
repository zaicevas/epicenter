using System;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post([FromBody] string value)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\ferN\plate_testing\FNN883.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            _plateService.Recognize("noob");
            //System.Diagnostics.Debug.WriteLine(plateResponse.Message);
            return Ok("ALL GOOD BOY");
        }
    }
}
