using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if (true)                           // if both person and plate has been recognized
                return Ok("ALL GOOD BOY");
            else
            {
                NotFound("Plate has not been found");
            }
        }
    }
}
