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
        public async System.Threading.Tasks.Task<IActionResult> PostAsync([FromBody] string value)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\stong\Desktop\TOP\imgs\Obama5.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
<<<<<<< HEAD
            PersonResponse personResponse = await new FaceService().RecognizeAsync(base64ImageRepresentation);
            PlateResponse plateResponse = new PlateService().Recognize(base64ImageRepresentation);
            System.Diagnostics.Debug.WriteLine(plateResponse.Message);
            System.Diagnostics.Debug.WriteLine(personResponse.Message);
=======
            //PlateResponse plateResponse = new PlateService().Recognize("noob");
            //System.Diagnostics.Debug.WriteLine(plateResponse.Message);
>>>>>>> 5dfd2f85f9a2f518aa102721ffd13ccdd3becdb3
            return Ok("ALL GOOD BOY");
        }
    }
}
