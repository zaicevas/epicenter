using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        public IActionResult Post([FromBody] string value)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\ferN\plate_testing\FNN883.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            PlateResponse plateResponse = new PlateService().Recognize(base64ImageRepresentation);
            System.Diagnostics.Debug.WriteLine(plateResponse.Message);
            return Ok("ALL GOOD BOY");
        }
    }
}
